using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Enrolement
{
    public string IdEnrolement { get; set; } = null!;

    public DateOnly DateEnrolement { get; set; }

    public string IdUserValidateur { get; set; } = null!;

    public string IdAffaire { get; set; } = null!;





    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserValidateurNavigation { get; set; } = null!;
}
