using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Payement
{
    public int IdPayement { get; set; }

    public double MontantRecu { get; set; }

    public int IdTypePayement { get; set; }

    public string IdUserValidateur { get; set; } = null!;

    public DateOnly DateValidation { get; set; }

    public string IdAffaire { get; set; } = null!;




    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual TypePayement IdTypePayementNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserValidateurNavigation { get; set; } = null!;
}
