using System;
using System.Collections.Generic;

namespace BL.Dtos;

public partial class ShipmentStatusDto : BaseDto
{
    public Guid? ShipmentId { get; set; }

    public string? Notes { get; set; }

}
