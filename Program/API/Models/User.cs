namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class User
{
    public int Id { get; set; }
    public string Brugernavn { get; set; } = null!;
    //1 billede per bruger. Billede er i image format på databasen
    public byte[]? Billede { get; set; }
    public string Adgangskode { get; set; } = null!;
    public DateOnly Oprettelsesdato { get; set; }

    //Alt herunder er database relation
    public ICollection<Anmeldelser> Anmeldelsers { get; set; }
    public ICollection<Kommentar> Kommentars { get; set; }
}
