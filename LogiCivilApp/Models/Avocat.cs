using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Avocat
{
    public string IdAvocat { get; set; } = null!;

    public string NumOrdre { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int? Genre { get; set; }

    public string? Telephone { get; set; }

    public string Adresse { get; set; } = null!;
    public DateOnly DateNaissance { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateInscription { get; set; }

    public DateOnly? DateValidationInscription { get; set; }

    public string? IdUtilisateurValidateur { get; set; }

    public int Etat { get; set; }

 


    public virtual Utilisateur? IdUtilisateurValidateurNavigation { get; set; }




    public virtual ICollection<Affaire> AffaireIdAvocatDefendeurNavigations { get; set; } = new List<Affaire>();

    public virtual ICollection<Affaire> AffaireIdAvocatDemandeurNavigations { get; set; } = new List<Affaire>();
}
