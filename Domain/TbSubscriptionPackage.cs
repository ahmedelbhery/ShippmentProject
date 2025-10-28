using System;
using System.Collections.Generic;

namespace Domain;

public partial class TbSubscriptionPackage: BaseTable
{

    public string PackageName { get; set; } = null!;

    public int ShipimentCount { get; set; }

    public double NumberOfKiloMeters { get; set; }

    public double TotalWeight { get; set; }

    public virtual ICollection<TbUserSubscription> TbUserSubscriptions { get; set; } = new List<TbUserSubscription>();
}
