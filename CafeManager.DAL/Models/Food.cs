using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Idcategory { get; set; }

    public decimal Price { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Billinfo> Billinfos { get; set; } = new List<Billinfo>();

    public virtual Productcategory IdcategoryNavigation { get; set; } = null!;
}
