using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class NatureAffaire
{
    public int IdNatureAffaire { get; set; }

    public string? Libelle { get; set; }

    public string? PieceAfournir { get; set; }

    public double Prix { get; set; }

    public int AffaireCommunicable { get; set; }





    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
