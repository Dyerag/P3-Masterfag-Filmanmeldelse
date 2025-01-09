namespace Api.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Direktør
{
    public int Id { get; set; }
    public string Fuldenavn { get; set; } = null!; //null! betyder "Not Nullable" i databasen

    //Alt herunder er database relation
    public ICollection<FilmDirektør> FilmDirektørs { get; set; }
}
//todo make a DTO, interface, repository and controller for Direktør