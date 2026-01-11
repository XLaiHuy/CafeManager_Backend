using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Productcategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
