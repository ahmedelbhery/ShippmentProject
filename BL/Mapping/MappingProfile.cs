using AutoMapper;
using BL.Dtos;
using Domain;
namespace BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<TbCarrier,CarrierDto>().ReverseMap();
            CreateMap<TbCity, CityDto>().ReverseMap();
            CreateMap<VwCities, CityDto>().ReverseMap();
            CreateMap<TbPaymentMethod, PaymentMethodDto>().ReverseMap();
            CreateMap<TbCountry, CountryDto>().ReverseMap();
            CreateMap<TbRefreshTokens, RefreshTokenDto>().ReverseMap();
            CreateMap<TbPaymentMethod, PaymentMethodDto>().ReverseMap();
            CreateMap<TbSetting, SettingDto>().ReverseMap();
            CreateMap<TbShipingType, ShipingTypeDto>().ReverseMap();
            CreateMap<TbShipment, ShipmentDto>().ReverseMap();
            CreateMap<TbShipmentStatus, ShipmentStatusDto>().ReverseMap();
            CreateMap<TbSubscriptionPackage, SubscriptionPackageDto>().ReverseMap();
            CreateMap<TbUserSender, UserSenderDto>().ReverseMap();
            CreateMap<TbUserReceiver, UserReceiverDto>().ReverseMap();
            CreateMap<TbUserSubscription, UserSubscriptionDto>().ReverseMap();
            CreateMap<TbShipingPackaging, ShipingPackgingDto>().ReverseMap();
        }
    }
}
