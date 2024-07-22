using System;
using System.Collections.Generic;

namespace LogiCivilApp.Models;

public partial class DetailsRenvoie
{
    public int IdMotifRenvoie { get; set; }

    public int IdRenvoie { get; set; }





    public virtual MotifRenvoie IdMotifRenvoieNavigation { get; set; } = null!;

    public virtual Renvoie IdRenvoieNavigation { get; set; } = null!;
}
