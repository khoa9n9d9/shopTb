using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Order
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public int Type { get; set; }

    public int Status { get; set; }

    public float SubTotal { get; set; }

    public float ItemDiscount { get; set; }

    public float Tax { get; set; }

    public float Shipping { get; set; }

    public float Total { get; set; }

    public string? Promo { get; set; }

    public float Discount { get; set; }

    public float GrandTotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
