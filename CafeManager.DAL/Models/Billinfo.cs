using System;
using System.Collections.Generic;

namespace CafeManager.DAL.Models;

public partial class Billinfo
{
    public int Id { get; set; }

    public int Idbill { get; set; }

    public int Idfood { get; set; }

    public int Count { get; set; }

    public decimal Priceatsale { get; set; }

    public virtual Bill IdbillNavigation { get; set; } = null!;

    public virtual Food IdfoodNavigation { get; set; } = null!;
}
