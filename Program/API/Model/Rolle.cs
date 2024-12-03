using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Rolle
{
    public int FilmId { get; set; }

    public string Rollenavn { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<SkuespillerRolle> SkuespillerRolles { get; set; } = new List<SkuespillerRolle>();
}
