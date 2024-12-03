using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Film
{
    public int Id { get; set; }

    public string Titel { get; set; } = null!;

    public byte[] Plakat { get; set; } = null!;

    public string Synopse { get; set; } = null!;

    public int Aldersgrænse { get; set; }

    public DateOnly Udgivelsesdato { get; set; }

    public TimeOnly Spilletid { get; set; }

    public decimal Gennemsnitsanmeldelse { get; set; }

    public virtual ICollection<Anmeldelse> Anmeldelses { get; set; } = new List<Anmeldelse>();

    public virtual ICollection<Rolle> Rolles { get; set; } = new List<Rolle>();

    public virtual ICollection<Direktør> Direktørs { get; set; } = new List<Direktør>();

    public virtual ICollection<Forfatter> Forfatters { get; set; } = new List<Forfatter>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Komponist> Komponists { get; set; } = new List<Komponist>();

    public virtual ICollection<Producer> Producers { get; set; } = new List<Producer>();
}
