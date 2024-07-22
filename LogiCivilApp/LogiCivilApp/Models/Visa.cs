using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Visa
{
    public int IdVisa { get; set; }

    public int IdSection { get; set; }

    public int IdSalleAudience { get; set; }

    public DateTime DateHeureAudience { get; set; }

    public int IdSousSection { get; set; }

    public int IdNatureAffaire { get; set; }

    public int IdTypeDossier { get; set; }

    public DateOnly DateCreation { get; set; }

    public string IdUserValidateur { get; set; } = null!;

    public string IdAffaire { get; set; } = null!;




    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual NatureAffaire IdNatureAffaireNavigation { get; set; } = null!;

    public virtual SalleAudience IdSalleAudienceNavigation { get; set; } = null!;

    public virtual Section IdSectionNavigation { get; set; } = null!;

    public virtual SousSection IdSousSectionNavigation { get; set; } = null!;

    public virtual TypeDossier IdTypeDossierNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserValidateurNavigation { get; set; } = null!;
}
