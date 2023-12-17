using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class ProductMetum
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string Key { get; set; } = null!;

    public string? Content { get; set; }

    public virtual Product Product { get; set; } = null!;
}
