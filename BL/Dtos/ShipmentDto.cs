using System;
using System.Collections.Generic;

namespace BL.Dtos;

public partial class ShipmentDto : BaseDto
{
    public DateTime ShipingDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public Guid SenderId { get; set; }

    public UserSenderDto UserSender { get; set; }

    public Guid ReceiverId { get; set; }

    public UserReceiverDto UserReceiver { get; set; }

    public Guid ShipingTypeId { get; set; }

    public Guid? ShipingPackgingId { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public double Length { get; set; }

    public decimal PackageValue { get; set; }

    public decimal ShipingRate { get; set; }

    public Guid? PaymentMethodId { get; set; }

    public Guid? UserSubscriptionId { get; set; }

    public string? TrackingNumber { get; set; }

    public Guid? ReferenceId { get; set; }

    public Guid? CarrierId { get; set; }
}
