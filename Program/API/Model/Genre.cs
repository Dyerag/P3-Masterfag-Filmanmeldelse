using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Genre
{
    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
