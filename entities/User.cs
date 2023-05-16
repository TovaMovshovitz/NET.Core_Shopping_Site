using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [StringLength(20, ErrorMessage = "string length must be between 4-20", MinimumLength = 4)]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
