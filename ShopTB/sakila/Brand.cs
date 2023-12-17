using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Brand
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Summary { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
