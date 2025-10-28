using BL.Contract;
using BL.Contract.Shipment;
using BL.Contracts;
using BL.Dtos;

namespace BL.Services.Shipment
{
    public class ShippedShipment : IShipmentStateHandler
    {
        IShipmentCommand _shipment;
        IShipmentStatus _status;
        IUserService _userService;
        public ShippedShipment(IShipmentCommand shipment, IShipmentStatus status,
            IUserService IUserService)
        {
            _shipment = shipment;
            _status = status;
            _userService = IUserService;
        }

        public ShipmentStatusEnum TargetState { get => ShipmentStatusEnum.Shipped; }

        public async Task HandleState(ShipmentDto shipment)
        {
            var userId = _userService.GetLoggedInUser();
            await _shipment.EditFields(shipment.Id, a =>
            {
                a.DeliveryDate = shipment.DeliveryDate;
                a.CurrentState = (int)TargetState;
                a.UpdatedBy = userId;
                a.UpdatedDate = DateTime.UtcNow;
            });
            await _shipment.ChangeStatus(shipment.Id, (int)TargetState);
            await _status.Add(shipment.Id, TargetState);
        }
    }
}
