using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domain;

namespace BL.Services
{
    public class PaymentMethodsService : BaseService<TbPaymentMethod,PaymentMethodDto>,IPaymentMethods
    {
        public PaymentMethodsService(IGenricRepository<TbPaymentMethod> repo,IMapper mapper,
             IUserService userService) : base(repo,mapper, userService)
        {

        }
    }
}
