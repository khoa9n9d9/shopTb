using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class OrderItem
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long ItemId { get; set; }

    public long OrderId { get; set; }

    public string Sku { get; set; } = null!;

    public float Price { get; set; }

    public float Discount { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
