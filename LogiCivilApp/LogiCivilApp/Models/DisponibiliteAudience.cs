using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class DisponibiliteAudience
{
    public int IdDisponibiliteAudience { get; set; }

    public TimeOnly HeureDebut { get; set; }

    public int JourSemaine { get; set; }

    public int IdSection { get; set; }





    public virtual Section IdSectionNavigation { get; set; } = null!;
}
