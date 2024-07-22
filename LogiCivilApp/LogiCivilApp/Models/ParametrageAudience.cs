using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class ParametrageAudience
{
    public int IdParametrageAudience { get; set; }

    public int TypeAudience { get; set; }

    public int HuisClos { get; set; }

    public DateTime DateHeureAudienceAjour { get; set; }

    public string IdUserValidateur { get; set; } = null!;

    public string IdAffaire { get; set; } = null!;





    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserValidateurNavigation { get; set; } = null!;
}
