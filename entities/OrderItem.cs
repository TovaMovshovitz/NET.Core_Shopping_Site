using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int ProuctId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }
    
    public virtual Order? Order { get; set; } = null!;
    
    public virtual Product? Prouct { get; set; } = null!;
}
