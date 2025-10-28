using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public partial class TbShipment:BaseTable
{

    public DateTime ShipingDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

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

    public virtual TbPaymentMethod? PaymentMethod { get; set; }

    public virtual TbUserReceiver Receiver { get; set; } = null!;

    public virtual TbUserSender Sender { get; set; } = null!;

    public virtual TbShipingType ShipingType { get; set; } = null!;

    [ForeignKey("ShipingPackgingId")]
    public virtual TbShipingPackaging? ShipingPackaging { get; set; }

    public virtual TbCarrier Carrier { get; set; } = null!;

    public virtual ICollection<TbShipmentStatus> TbShipmentStatuses { get; set; } = new List<TbShipmentStatus>();
}
