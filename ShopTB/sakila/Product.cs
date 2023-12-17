using System;
using System.Collections.Generic;
using ShopTB.sakila;

namespace ShopTB.sakila;

public partial class Product
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Summary { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductMetum> ProductMeta { get; set; } = new List<ProductMetum>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}