using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Transaction
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long OrderId { get; set; }

    public string Code { get; set; } = null!;

    public int Type { get; set; }

    public int Mode { get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
