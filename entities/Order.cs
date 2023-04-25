using System;
using System.Collections.Generic;

namespace entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? Sum { get; set; }

    public int? UserId { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();//????????????????

    public virtual User? User { get; set; }
}