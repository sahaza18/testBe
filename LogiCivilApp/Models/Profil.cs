using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Profil
{
    public int IdProfil { get; set; }

    public string? Nom { get; set; }




    public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
}
