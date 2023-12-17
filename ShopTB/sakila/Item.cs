using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Item
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long BrandId { get; set; }

    public long SupplierId { get; set; }

    public long OrderId { get; set; }

    public string Sku { get; set; } = null!;

    public float Mrp { get; set; }

    public float Discount { get; set; }

    public float Price { get; set; }

    public int Quantity { get; set; }

    public int Sold { get; set; }

    public int Available { get; set; }

    public int Defective { get; set; }

    public long CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual Customer Supplier { get; set; } = null!;
}
