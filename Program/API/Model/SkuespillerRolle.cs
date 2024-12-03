using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class SkuespillerRolle
{
    public int FilmId { get; set; }

    public string Rollenavn { get; set; } = null!;

    public int SkuespillerId { get; set; }

    public string RolleType { get; set; } = null!;

    public virtual Rolle Rolle { get; set; } = null!;

    public virtual Skuespiller Skuespiller { get; set; } = null!;
}
