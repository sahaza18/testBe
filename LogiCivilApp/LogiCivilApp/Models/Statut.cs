using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Statut
{
    public int IdStatut { get; set; }

    public string? Nom { get; set; }

    public int ValeurEtape { get; set; }




    public virtual ICollection<Affaire> Affaires { get; set; } = new List<Affaire>();

    public virtual ICollection<HistoriqueTraitementAffaire> HistoriqueTraitementAffaires { get; set; } = new List<HistoriqueTraitementAffaire>();
}
