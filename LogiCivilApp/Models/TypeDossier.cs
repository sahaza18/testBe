using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class TypeDossier
{
    public int IdTypeDossier { get; set; }

    public string? Libelle { get; set; }

    public double Prix { get; set; }




    public virtual ICollection<StandardServiceType> StandardServiceTypes { get; set; } = new List<StandardServiceType>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
