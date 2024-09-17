﻿using System;
using System.Collections.Generic;

namespace ClassicModelDomain.DataEntities;

public partial class Productline
{
    public string ProductLine1 { get; set; } = null!;

    public string? TextDescription { get; set; }

    public string? HtmlDescription { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
