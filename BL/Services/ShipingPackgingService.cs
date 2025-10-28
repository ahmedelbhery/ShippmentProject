using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domain;

namespace BL.Services
{
    public class ShipingPackgingService : BaseService<TbShipingPackaging, ShipingPackgingDto>,IPackgingTypes
    {
        public ShipingPackgingService(IGenricRepository<TbShipingPackaging> repo,IMapper mapper,
             IUserService userService) : base(repo,mapper, userService)
        {

        }
    }
}
