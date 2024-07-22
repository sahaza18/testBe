using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class HistoriqueTraitementAffaire
{
    public int IdHistoriqueTraitementAffaire { get; set; }

    public string IdAffaire { get; set; } = null!;

    public int IdStatut { get; set; }

    public DateOnly DateChangement { get; set; }





    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;
}
