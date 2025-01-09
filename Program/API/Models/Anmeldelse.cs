namespace Api.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Anmeldelse
{
    //Id'en til den film anmeldelsen tilhører
    public int FilmId { get; set; }
    //Anmelderens brugerId
    public int AnmelderId { get; set; }
    public string? Titel { get; set; }
    public string? Begrundelse { get; set; }
    //1 - 5 Stjerner
    public int Bedømmelse { get; set; }
    //hvornår anmeldelsen blev givet. fås automatisk
    public DateOnly Anmeldsdato { get; set; }

    //Alt herunder er database relation
    public User Anmelder { get; set; } = null!; //null! betyder not nullable i databasen
    public Film Film { get; set; } = null!;
    public ICollection<Kommentar> Kommentars { get; set; } = [];
}
//todo make a controller for Anmeldelser