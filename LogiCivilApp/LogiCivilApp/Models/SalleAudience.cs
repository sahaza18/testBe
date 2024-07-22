using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class SalleAudience
{
    public int IdSalleAudience { get; set; }

    public string? Nom { get; set; }




    public virtual Section? Section { get; set; }




    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
