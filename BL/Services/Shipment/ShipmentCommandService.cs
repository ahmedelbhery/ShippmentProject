using AutoMapper;
using BL.Contract;
using BL.Contracts;
using BL.Contracts.Shipment;
using BL.Dtos;
using DAL.Contracts;
using Domain;

namespace BL.Services
{
    public class ShipmentCommandService : BaseService<TbShipment, ShipmentDto>, IShipmentCommand
    {
        IUserReceiver _userReceiver;
        IUserSender _userSender;
        ITrackingNumberCreator _trackingCreator;
        IRateCalculator _rateCalculator;
        IUnitOfWork _uow;
        IUserService _userService;
        IGenricRepository<TbShipment> _repo;
        IMapper _mapper;
        IShipmentStatus _shipmentStatus;
        public ShipmentCommandService(IGenricRepository<TbShipment> repo, IMapper mapper,
             IUserService userService, IUserReceiver userReceiver,
             IUserSender userSender, ITrackingNumberCreator trackingCreator
            , IRateCalculator rateCalculator, IShipmentStatus shipmentStatus, IUnitOfWork uow) : base(uow, mapper, userService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _userReceiver = userReceiver;
            _userSender = userSender;
            _trackingCreator = trackingCreator;
            _rateCalculator = rateCalculator;
            _userService = userService;
            _shipmentStatus = shipmentStatus;
        }

        public async Task Create(ShipmentDto dto)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                // create tracking number
                dto.TrackingNumber = _trackingCreator.Create();
                // calculate date
                dto.ShipingRate = _rateCalculator.Calculate(dto);
                // save sender
                var userId = _userService.GetLoggedInUser();
                if (dto.SenderId == Guid.Empty)
                {
                    dto.UserSender.UserId = userId;
                    var senderResult=await _userSender.Add(dto.UserSender);
                    dto.SenderId = senderResult.Item2;
                }
                // save receiver
                if (dto.ReceiverId == Guid.Empty)
                {
                    dto.UserReceiver.UserId = userId;
                    var reciverResult=await _userReceiver.Add(dto.UserReceiver);
                    dto.ReceiverId = reciverResult.Item2;
                }
                //  حفظ الشحنة واسترجاع Id الخاص بها
                var (isSaved, gShipmentId) = await this.Add(dto);

                // حفظ الحالة الأولى للشحنة (Created)
                if (isSaved)
                    await _shipmentStatus.Add(gShipmentId, ShipmentStatusEnum.Created);

                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new Exception();
            }
        }

        public async Task Edit(ShipmentDto dto)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                // calculate date
                dto.ShipingRate = _rateCalculator.Calculate(dto);
                var userId = _userService.GetLoggedInUser();
                // save sender
                dto.UserSender.Id = dto.SenderId;
                await _userSender.Update(dto.UserSender);
                // save receiver
                if (dto.ReceiverId == Guid.Empty)
                {
                    dto.UserReceiver.UserId = userId;
                    var receiverResult = await _userReceiver.Add(dto.UserReceiver);
                    dto.ReceiverId = receiverResult.Item2;
                }
                else
                {
                    dto.UserReceiver.Id = dto.ReceiverId;
                    await _userReceiver.Update(dto.UserReceiver);
                }
                // save shipment
                await this.Update(dto);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                throw new Exception();
            }
        }

        public async Task EditFields(Guid id, Action<TbShipment> updateAction)
        {
            await _repo.Update(id, updateAction);
        }
    }
}
