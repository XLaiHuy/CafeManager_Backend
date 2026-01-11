using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Displayname { get; set; } = null!;

    public int Type { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
