namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Genre
{
    /*Scaffolding lagde 1 sidst i navnet, fordi ingen medlemmer må
     * dele navn med sin enclosing type. Enclosing Type er klassens navn*/
    public string Genre1 { get; set; } = null!;

    //Alt herunder er database relation
    public ICollection<FilmGenre> FilmGenres { get; set; }
}