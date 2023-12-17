using System;
using System.Collections.Generic;

namespace ShopTB.sakila;

public partial class Customer
{
    public long Id { get; set; }

    public short RoleId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Intro { get; set; }

    public string? Profile { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
