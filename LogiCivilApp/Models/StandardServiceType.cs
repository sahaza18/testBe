using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class StandardServiceType
{
    public int IdStandardServiceType { get; set; }

    public int IdTypeDossier { get; set; }

    public double AttenteParametrage { get; set; }

    public double AttenteValidationPlumitif { get; set; }




    public virtual TypeDossier IdTypeDossierNavigation { get; set; } = null!;
}
