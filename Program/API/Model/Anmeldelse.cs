using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Anmeldelse
{
    public int FilmId { get; set; }

    public int AnmelderId { get; set; }

    public string? Titel { get; set; }

    public string? Begrundelse { get; set; }

    public int Bedømmelse { get; set; }

    public DateOnly Anmeldsdato { get; set; }

    public virtual User Anmelder { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<Kommentar> Kommentars { get; set; } = new List<Kommentar>();
}
