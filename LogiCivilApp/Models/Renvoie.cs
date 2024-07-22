using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Renvoie
{
    public int IdRenvoie { get; set; }

    public DateOnly DateRenvoie { get; set; }

    public string IdUserResponsable { get; set; } = null!;

    public string IdAffaire { get; set; } = null!;




    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserResponsableNavigation { get; set; } = null!;
}
