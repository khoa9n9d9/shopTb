using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Category
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
