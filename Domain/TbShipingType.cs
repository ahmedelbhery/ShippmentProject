using System;
using System.Collections.Generic;
namespace Domain;

public partial class TbShipingType : BaseTable
{

    public string? ShipingTypeAname { get; set; }

    public string? ShipingTypeEname { get; set; }

    public double ShipingFactor { get; set; }

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();
}
