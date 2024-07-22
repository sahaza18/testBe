using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Section
{
    public int IdSection { get; set; }

    public string? Nom { get; set; }

    public int IdSalleAudience { get; set; }




    public virtual SalleAudience IdSalleAudienceNavigation { get; set; } = null!;




    public virtual ICollection<DisponibiliteAudience> DisponibiliteAudiences { get; set; } = new List<DisponibiliteAudience>();

    public virtual ICollection<SousSection> SousSections { get; set; } = new List<SousSection>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
