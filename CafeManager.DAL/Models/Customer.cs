using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
