using System;
using System.Collections.Generic;

namespace ClassicModelDomain.DataEntities;

public partial class Payment
{
    public int CustomerNumber { get; set; }

    public string CheckNumber { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public virtual Customer CustomerNumberNavigation { get; set; } = null!;
}
