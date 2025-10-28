#region Usings
using BL.Contract;
using BL.Contract.Shipment;
using BL.Contracts;
using BL.Contracts.Shipment;
using BL.Dtos;
using BL.Mapping;
using BL.Services;
using BL.Services.Shipment;
using DAL;
using DAL.Contracts;
using DAL.DBContext;
using DAL.Repositiories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net.Http.Headers;
using UI.Services; 
#endregion

namespace UI
{
    public class RegisterServicesHelper
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient("ApiClient", client =>
            {
                // Base URL will be configured in GenericApiClient constructor using appsettings.json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            });


            #region configure authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/login";
                 options.AccessDeniedPath = "/access-denied";
                 options.SlidingExpiration = true;
                 options.Cookie.IsEssential = true;
                 options.ExpireTimeSpan = TimeSpan.FromDays(7);
             }); 
            #endregion

            #region dbConnection
            builder.Services.AddDbContext<ShipingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region configure Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ShipingContext>()
              .AddDefaultTokenProviders(); 
            #endregion

            builder.Services.AddAuthorization();

            #region logger configuration
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                    tableName: "Log",
                    autoCreateSqlTable: true)
                .CreateLogger();
            builder.Host.UseSerilog();
            #endregion

            #region Services
            builder.Services.AddScoped<GenericApiClient>();
            builder.Services.AddScoped(typeof(IGenricRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IViewRepository<>), typeof(ViewRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IShippingType, ShippingTypeService>();
            builder.Services.AddScoped<ICarrier, CarrierService>();
            builder.Services.AddScoped<ICountry, CountryService>();
            builder.Services.AddScoped<ICity, CityService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPaymentMethods, PaymentMethodsService>();
            builder.Services.AddScoped<IPackgingTypes, ShipingPackgingService>();
            builder.Services.AddScoped<IUserSender, UserSenderService>();
            builder.Services.AddScoped<IUserReceiver, UserReceiverService>();
            builder.Services.AddScoped<ITrackingNumberCreator, TrackingNumberCreatorService>();
            builder.Services.AddScoped<IRateCalculator, RateCalculatorService>();
            builder.Services.AddScoped<IShipmentStatus, ShipmentStatusService>();

            builder.Services.AddScoped<IShipmentCommand, ShipmentCommandService>();
            builder.Services.AddScoped<IShipmentQuery, ShipmentQueryService>();
            builder.Services.AddScoped<IShipmentStateHandlerFactory, ShipmentStateHandlerFactory>();
            builder.Services.AddScoped<ApproveShipment>();
            builder.Services.AddScoped<ReadyShipment>();
            builder.Services.AddScoped<ShippedShipment>();
            builder.Services.AddScoped<DelivredShipment>();
            builder.Services.AddScoped<ReturnedShipment>();

            builder.Services.AddScoped<IRefreshTokens, RefreshTokenServic>();
            #endregion

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
