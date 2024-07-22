using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class Plumitif
{
    public int IdPlumitif { get; set; }

    public string IdUserRedacteur { get; set; } = null!;

    public DateOnly DateRedaction { get; set; }

    public string? IdUserValidateur { get; set; }

    public DateOnly? DateValidation { get; set; }

    public string Jugement { get; set; } = null!;

    public string IdAffaire { get; set; } = null!;




    public virtual Affaire IdAffaireNavigation { get; set; } = null!;

    public virtual Utilisateur IdUserRedacteurNavigation { get; set; } = null!;

    public virtual Utilisateur? IdUserValidateurNavigation { get; set; }

    public virtual ICollection<QuestionnairePlumitif> QuestionnairePlumitifs { get; set; } = new List<QuestionnairePlumitif>();
}
