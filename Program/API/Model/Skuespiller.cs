using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Skuespiller
{
    public int Id { get; set; }

    public string Fuldenavn { get; set; } = null!;

    public virtual ICollection<SkuespillerRolle> SkuespillerRolles { get; set; } = new List<SkuespillerRolle>();
}
