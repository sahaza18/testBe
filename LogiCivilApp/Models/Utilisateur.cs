using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Utilisateur
{
    public string IdUtilisateur { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    public int Genre { get; set; }

    public string? Telephone { get; set; }

    public string? Adresse { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateInscription { get; set; }

    public int IdProfil { get; set; }

    public int Etat { get; set; }




    public virtual Profil IdProfilNavigation { get; set; } = null!;




    public virtual ICollection<Affaire> AffaireIdProcureurNavigations { get; set; } = new List<Affaire>();

    public virtual ICollection<Affaire> AffaireIdUserValidateurCloturationNavigations { get; set; } = new List<Affaire>();

    public virtual ICollection<Affaire> AffaireIdUserValidateurDemandeNavigations { get; set; } = new List<Affaire>();

    public virtual ICollection<Avocat> Avocats { get; set; } = new List<Avocat>();

    public virtual ICollection<Enrolement> Enrolements { get; set; } = new List<Enrolement>();

    public virtual ICollection<ParametrageAudience> ParametrageAudiences { get; set; } = new List<ParametrageAudience>();

    public virtual ICollection<Payement> Payements { get; set; } = new List<Payement>();

    public virtual ICollection<Plumitif> PlumitifIdUserRedacteurNavigations { get; set; } = new List<Plumitif>();

    public virtual ICollection<Plumitif> PlumitifIdUserValidateurNavigations { get; set; } = new List<Plumitif>();

    public virtual ICollection<Renvoie> Renvoies { get; set; } = new List<Renvoie>();

    public virtual ICollection<SousSection> SousSectionIdUserGreffierAudiencierNavigations { get; set; } = new List<SousSection>();

    public virtual ICollection<SousSection> SousSectionIdUserJugeNavigations { get; set; } = new List<SousSection>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
