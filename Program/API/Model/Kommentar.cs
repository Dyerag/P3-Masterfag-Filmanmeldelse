using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Kommentar
{
    public int Id { get; set; }

    public string Kommentar1 { get; set; } = null!;

    public int KommentatorId { get; set; }

    public int AnmeldelsensAnmelderId { get; set; }

    public int AnmeldelsensFilmId { get; set; }

    public DateOnly KommentarDato { get; set; }

    public virtual Anmeldelse Anmeldelse { get; set; } = null!;

    public virtual User Kommentator { get; set; } = null!;
}
