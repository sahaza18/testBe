using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class TypePayement
{
    public int IdTypePayement { get; set; }

    public string? Nom { get; set; }




    public virtual ICollection<Payement> Payements { get; set; } = new List<Payement>();
}
