using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Affaire
{
    public string IdAffaire { get; set; } = null!;

    public string NomDemandeur { get; set; } = null!;

    public string? IdAvocatDemandeur { get; set; }

    public string NomDefendeur { get; set; } = null!;

    public string? IdAvocatDefendeur { get; set; }

    public string DescriptionAffaire { get; set; } = null!;

    public string IdUserValidateurDemande { get; set; } = null!;

    public DateOnly DateDemande { get; set; }

    public string? IdProcureur { get; set; }

    public DateOnly? DateValidationProcureur { get; set; }

    public string? IdUserValidateurCloturation { get; set; }

    public DateOnly? DateCloturationDossier { get; set; }

    public int IdStatut { get; set; }




 
    public virtual Avocat? IdAvocatDefendeurNavigation { get; set; }

    public virtual Avocat? IdAvocatDemandeurNavigation { get; set; }

    public virtual Utilisateur? IdProcureurNavigation { get; set; }

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual Utilisateur? IdUserValidateurCloturationNavigation { get; set; }

    public virtual Utilisateur IdUserValidateurDemandeNavigation { get; set; } = null!;




    public virtual ICollection<Enrolement> Enrolements { get; set; } = new List<Enrolement>();

    public virtual ICollection<HistoriqueTraitementAffaire> HistoriqueTraitementAffaires { get; set; } = new List<HistoriqueTraitementAffaire>();

    public virtual ICollection<ParametrageAudience> ParametrageAudiences { get; set; } = new List<ParametrageAudience>();

    public virtual ICollection<Payement> Payements { get; set; } = new List<Payement>();

    public virtual ICollection<Plumitif> Plumitifs { get; set; } = new List<Plumitif>();

    public virtual ICollection<Renvoie> Renvoies { get; set; } = new List<Renvoie>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
