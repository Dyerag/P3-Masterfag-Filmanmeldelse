using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class User
{
    public int Id { get; set; }

    public string Brugernavn { get; set; } = null!;

    public byte[]? Billede { get; set; }

    public string Adgangskode { get; set; } = null!;

    public DateOnly Oprettelsesdato { get; set; }

    public virtual ICollection<Anmeldelse> Anmeldelses { get; set; } = new List<Anmeldelse>();

    public virtual ICollection<Kommentar> Kommentars { get; set; } = new List<Kommentar>();
}
