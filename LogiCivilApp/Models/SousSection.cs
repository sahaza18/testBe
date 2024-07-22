using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class SousSection
{
    public int IdSousSection { get; set; }

    public string? Nom { get; set; }

    public string IdUserJuge { get; set; } = null!;

    public string IdUserGreffierAudiencier { get; set; } = null!;

    public int IdSection { get; set; }

    public int Etat { get; set; }




    public virtual Section IdSectionNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserGreffierAudiencierNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserJugeNavigation { get; set; } = null!;




    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
