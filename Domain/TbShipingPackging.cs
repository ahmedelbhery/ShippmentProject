using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

public partial class TbShipingPackaging : BaseTable
{

    public string? ShipingPackagingAname { get; set; }

    public string? ShipingPackagingEname { get; set; }


    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();
}
