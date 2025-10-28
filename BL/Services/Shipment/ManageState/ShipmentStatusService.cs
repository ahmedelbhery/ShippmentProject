using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Contract;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domain;

namespace BL.Services
{
    public class ShipmentStatusService : BaseService<TbShipmentStatus, ShipmentStatusDto>, IShipmentStatus
    {
        IUnitOfWork _uow;
        IUserService _userService;
        IGenricRepository<TbShipmentStatus> _repo;
        IMapper _mapper;
        public ShipmentStatusService(IGenricRepository<TbShipmentStatus> repo, IMapper mapper,
             IUserService userService, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<(bool, Guid)> Add(Guid shipmentId, ShipmentStatusEnum status)
        {
            ShipmentStatusDto oStatus = new ShipmentStatusDto();
            oStatus.ShipmentId = shipmentId;
            oStatus.CurrentState = (int)status;
            var dbObject = _mapper.Map<ShipmentStatusDto, TbShipmentStatus>(oStatus);
            dbObject.CreatedBy = _userService.GetLoggedInUser();
            dbObject.CurrentState = 1;

            return await _repo.Add(dbObject);
        }
    }
}
