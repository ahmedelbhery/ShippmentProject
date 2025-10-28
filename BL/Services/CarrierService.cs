using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domain;

namespace BL.Services
{
    public class CarrierService : BaseService<TbCarrier,CarrierDto>,ICarrier
    {
        public CarrierService(IGenricRepository<TbCarrier> repo,IMapper mapper,
            IUserService userService) : base(repo,mapper, userService)
        {

        }
    }
}
