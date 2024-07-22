using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class QuestionnairePlumitif
{
    public int IdQuestionnairePlumitif { get; set; }

    public int IdPlumitif { get; set; }

    public string Question { get; set; } = null!;

    public string Reponse { get; set; } = null!;

    public string NomInterroger { get; set; } = null!;




    public virtual Plumitif IdPlumitifNavigation { get; set; } = null!;
}
