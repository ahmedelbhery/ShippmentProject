using AutoMapper;
using DAL.Contracts;
using BL.Dtos;
using Domain;
using BL.Contracts;

namespace BL.Services
{
    public class UserReceiverService : BaseService<TbUserReceiver, UserReceiverDto>,IUserReceiver
    {
        IUnitOfWork _uow;
        public UserReceiverService(IGenricRepository<TbUserReceiver> repo,IMapper mapper,
             IUserService userService, IUnitOfWork uow) : base(uow, mapper, userService)
        {

        }
    }
}
