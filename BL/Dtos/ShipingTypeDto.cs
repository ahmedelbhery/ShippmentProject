using AppResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.Dtos;

public partial class ShipingTypeDto : BaseDto
{
    [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
    public string? ShipingTypeAname { get; set; }
    [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
    public string? ShipingTypeEname { get; set; }
    [Required(ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping), AllowEmptyStrings = false)]
    [Range(0.25, 10, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
    public double ShipingFactor { get; set; }
}
