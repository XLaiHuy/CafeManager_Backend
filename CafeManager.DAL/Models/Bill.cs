using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime Datecheckin { get; set; }

    public int? Idtable { get; set; }

    public int Status { get; set; }

    public int? Discount { get; set; }

    public int Idaccount { get; set; }

    public int? Idcustomer { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Billinfo> Billinfos { get; set; } = new List<Billinfo>();

    public virtual Account IdaccountNavigation { get; set; } = null!;

    public virtual Customer? IdcustomerNavigation { get; set; }

    public virtual Tablefood? IdtableNavigation { get; set; }
}
