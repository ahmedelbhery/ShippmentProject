using AutoMapper;
using BL.Contract;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using DAL.Models;
using Domain;

namespace BL.Services
{
    public class ShipmentQueryService : BaseService<TbShipment, ShipmentDto>, IShipmentQuery
    {
        IUserService _userService;
        IGenricRepository<TbShipment> _repo;
        public ShipmentQueryService(IGenricRepository<TbShipment> repo, IMapper mapper,
             IUserService userService) : base(repo, mapper, userService)
        {
            _repo = repo;
            _userService = userService;
        }

        public async Task<List<ShipmentDto>> GetShipments()
        {
            try
            {
                var userId = _userService.GetLoggedInUser();

                var shipments = await _repo.GetList(
                    filter: a => a.CreatedBy == userId,
                    selector: a => new ShipmentDto
                    {
                        Id = a.Id,
                        ShipingDate = a.ShipingDate,
                        DeliveryDate = a.DeliveryDate,
                        SenderId = a.SenderId,
                        ReceiverId = a.ReceiverId,
                        ShipingTypeId = a.ShipingTypeId,
                        ShipingPackgingId = a.ShipingPackgingId,
                        Width = a.Width,
                        Height = a.Height,
                        Weight = a.Weight,
                        Length = a.Length,
                        PackageValue = a.PackageValue,
                        ShipingRate = a.ShipingRate,
                        PaymentMethodId = a.PaymentMethodId,
                        UserSubscriptionId = a.UserSubscriptionId,
                        TrackingNumber = a.TrackingNumber,
                        ReferenceId = a.ReferenceId,
                        CurrentState = a.CurrentState,
                        UserSender = new UserSenderDto
                        {
                            Id = a.Sender.Id,
                            SenderName = a.Sender.SenderName,
                            Email = a.Sender.Email,
                            Phone = a.Sender.Phone
                        },
                        UserReceiver = new UserReceiverDto
                        {
                            Id = a.Receiver.Id,
                            ReceiverName = a.Receiver.ReceiverName,
                            Email = a.Receiver.Email,
                            Phone = a.Receiver.Phone
                        }
                    },
                    orderBy: a => a.CreatedDate,
                    isDescending: true,
                    a => a.Sender, a => a.Receiver
                );

                return shipments;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting shipments", ex);
            }
        }

        public async Task<PagedResult<ShipmentDto>> GetShipments(int pageNumber, int pageSize, bool isUserData, ShipmentStatusEnum? status)
        {
            try
            {
                int? nStatus = 0;
                if (status == null)
                    nStatus = null;
                else
                    nStatus = (int)status;

                var userId = _userService.GetLoggedInUser();

                var result = await _repo.GetPagedList(
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    filter: a => (a.CreatedBy == userId || !isUserData) && (a.CurrentState == nStatus || nStatus == null) && (a.CurrentState > 0),
                    selector: a => new ShipmentDto
                    {
                        Id = a.Id,
                        ShipingDate = a.ShipingDate,
                        DeliveryDate = a.DeliveryDate,
                        SenderId = a.SenderId,
                        ReceiverId = a.ReceiverId,
                        ShipingTypeId = a.ShipingTypeId,
                        ShipingPackgingId = a.ShipingPackgingId,
                        Width = a.Width,
                        Height = a.Height,
                        Weight = a.Weight,
                        Length = a.Length,
                        PackageValue = a.PackageValue,
                        ShipingRate = a.ShipingRate,
                        PaymentMethodId = a.PaymentMethodId,
                        UserSubscriptionId = a.UserSubscriptionId,
                        TrackingNumber = a.TrackingNumber,
                        ReferenceId = a.ReferenceId,
                        CurrentState = a.CurrentState,
                        UserSender = new UserSenderDto
                        {
                            Id = a.Sender.Id,
                            SenderName = a.Sender.SenderName,
                            Email = a.Sender.Email,
                            Phone = a.Sender.Phone
                        },
                        UserReceiver = new UserReceiverDto
                        {
                            Id = a.Receiver.Id,
                            ReceiverName = a.Receiver.ReceiverName,
                            Email = a.Receiver.Email,
                            Phone = a.Receiver.Phone
                        }
                    },
                    orderBy: a => a.CreatedDate,
                    isDescending: true,
                    a => a.Sender, a => a.Receiver
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting shipments", ex);
            }
        }

        public async Task<PagedResult<ShipmentDto>> GetAllShipments(int pageNumber, int pageSize)
        {
            try
            {

                var result = await _repo.GetPagedList(
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    filter: a => a.CurrentState > 0,
                    selector: a => new ShipmentDto
                    {
                        Id = a.Id,
                        ShipingDate = a.ShipingDate,
                        DeliveryDate = a.DeliveryDate,
                        SenderId = a.SenderId,
                        ReceiverId = a.ReceiverId,
                        ShipingTypeId = a.ShipingTypeId,
                        ShipingPackgingId = a.ShipingPackgingId,
                        Width = a.Width,
                        Height = a.Height,
                        Weight = a.Weight,
                        Length = a.Length,
                        PackageValue = a.PackageValue,
                        ShipingRate = a.ShipingRate,
                        PaymentMethodId = a.PaymentMethodId,
                        UserSubscriptionId = a.UserSubscriptionId,
                        TrackingNumber = a.TrackingNumber,
                        ReferenceId = a.ReferenceId,
                        CurrentState = a.CurrentState,
                        UserSender = new UserSenderDto
                        {
                            Id = a.Sender.Id,
                            SenderName = a.Sender.SenderName,
                            Email = a.Sender.Email,
                            Phone = a.Sender.Phone
                        },
                        UserReceiver = new UserReceiverDto
                        {
                            Id = a.Receiver.Id,
                            ReceiverName = a.Receiver.ReceiverName,
                            Email = a.Receiver.Email,
                            Phone = a.Receiver.Phone
                        }
                    },
                    orderBy: a => a.CreatedDate,
                    isDescending: true,
                    a => a.Sender, a => a.Receiver
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting shipments", ex);
            }
        }

        public async Task<ShipmentDto> GetShipment(Guid id)
        {
            try
            {
                //var userId = _userService.GetLoggedInUser();

                var shipments = await _repo.GetList(
                    filter: a => a.Id == id,
                    selector: a => new ShipmentDto
                    {
                        Id = a.Id,
                        ShipingDate = a.ShipingDate,
                        DeliveryDate = a.DeliveryDate,
                        SenderId = a.SenderId,
                        ReceiverId = a.ReceiverId,
                        ShipingTypeId = a.ShipingTypeId,
                        ShipingPackgingId = a.ShipingPackgingId,
                        Width = a.Width,
                        Height = a.Height,
                        Weight = a.Weight,
                        Length = a.Length,
                        PackageValue = a.PackageValue,
                        ShipingRate = a.ShipingRate,
                        PaymentMethodId = a.PaymentMethodId,
                        UserSubscriptionId = a.UserSubscriptionId,
                        TrackingNumber = a.TrackingNumber,
                        ReferenceId = a.ReferenceId,
                        CurrentState=a.CurrentState,
                        UserSender = new UserSenderDto
                        {
                            Id = a.Sender.Id,
                            SenderName = a.Sender.SenderName,
                            Email = a.Sender.Email,
                            Phone = a.Sender.Phone,
                            Address = a.Sender.Address,
                            Contact = a.Sender.Contact,
                            PostalCode = a.Sender.PostalCode,
                            OtherAddress = a.Sender.OtherAddress,
                            CityId = a.Sender.CityId,
                            CountryId = a.Sender.City.CountryId
                        },
                        UserReceiver = new UserReceiverDto
                        {
                            Id = a.Receiver.Id,
                            ReceiverName = a.Receiver.ReceiverName,
                            Email = a.Receiver.Email,
                            Phone = a.Receiver.Phone,
                            Address = a.Receiver.Address,
                            Contact = a.Receiver.Contact,
                            PostalCode = a.Receiver.PostalCode,
                            OtherAddress = a.Receiver.OtherAddress,
                            CityId = a.Receiver.CityId,
                            CountryId = a.Receiver.City.CountryId
                        }
                    },
                    orderBy: a => a.CreatedDate,
                    isDescending: true,
                    a => a.Sender,
                    a => a.Sender.City,
                    a => a.Sender.City.Country,
                    a => a.Receiver,
                    a => a.Receiver.City,
                    a => a.Receiver.City.Country
                );

                return shipments.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting shipment", ex);
            }
        }
    }
}
