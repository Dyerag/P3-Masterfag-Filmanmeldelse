namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Forfatter
{
    public int Id { get; set; }
    public string Fuldenavn { get; set; } = null!; //null! = Not Nullable

    //Alt herunder er database relation
    public ICollection<FilmForfatter>? FilmForfatters { get; set; }
}
