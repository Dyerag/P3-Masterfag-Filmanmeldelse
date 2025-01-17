namespace Api.Models;

/* Made som changes since scaffolding, to make it closer to how I would have written
 * it, if i had made it from the ground up. Removed partial, virtual and new.*/
public class Film
{
    public int Id { get; set; }
    public string Titel { get; set; } = null!;
    // There's only one poster(Plakat) per film, and in the database, it's type is image.
    public byte[] Plakat { get; set; } = null!;
    public string Synopse { get; set; } = null!;
    public int Aldersgrænse { get; set; }
    public DateOnly Udgivelsesdato { get; set; }
    public TimeOnly Spilletid { get; set; }
    // Calculates the Average rating in the Api, when a new review is written.
    public decimal Gennemsnitsanmeldelse { get; set; }

    // Past this point is just database relations.
    public ICollection<Anmeldelse> Anmeldelses { get; set; }
    public ICollection<Rolle> Rolles { get; set; }
    public ICollection<FilmDirektør> FilmDirektørs { get; set; }
    public ICollection<FilmForfatter> FilmForfatters { get; set; }
    public ICollection<FilmGenre> FilmGenres { get; set; }
    public ICollection<FilmKomponist> FilmKomponists { get; set; }
    public ICollection<FilmProducer> FilmProducers { get; set; }
}
