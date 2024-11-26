namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Film
{
    public int Id { get; set; }
    public string Titel { get; set; } = null!;
    //Der er kun 1 plakat per. film, og den er af datatypen image i databasen.
    public byte[] Plakat { get; set; } = null!;
    public string Synopse { get; set; } = null!;
    public int Aldersgrænse { get; set; }
    public DateOnly Udgivelsesdato { get; set; }
    public TimeOnly Spilletid { get; set; }
    //Beregnes her i programmet når en ny anmeldelse laves, og gemmes på databasen.
    public decimal Gennemsnitsanmeldelse { get; set; }

    //Alt herunder er database relation
    public ICollection<Anmeldelse> Anmeldelses { get; set; }
    public ICollection<Rolle> Rolles { get; set; }
    public ICollection<FilmDirektør> FilmDirektørs { get; set; }
    public ICollection<FilmForfatter> FilmForfatters { get; set; }
    public ICollection<FilmGenre> FilmGenres { get; set; }
    public ICollection<FilmKomponist> FilmKomponists { get; set; }
    public ICollection<FilmProducer> FilmProducers { get; set; }
}
