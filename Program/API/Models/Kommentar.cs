namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Kommentar
{
    public int Id { get; set; }
    /*Scaffolding lagde 1 sidst i navnet, fordi ingen medlemmer må
     * dele navn med sin enclosing type. Enclosing type er klassens navn*/
    public string Kommentar1 { get; set; } = null!;
    //Id'en på brugeren der skrev kommentaren
    public int KommentatorId { get; set; }
    //Anmeldelsestabellen bruger en composite key som primary key.
    //Derfor skal der bruges 2 kolonner for at få id'en til den anmeldelse som kommentaren tilhører
    public int AnmeldelsensAnmelderId { get; set; }
    public int AnmeldelsensFilmId { get; set; }
    public DateOnly KommentarDato { get; set; }

    //Alt herunder er database relation
    public Anmeldelser Anmeldelser { get; set; } = null!;
    public User Kommentator { get; set; } = null!;
}
//todo make a DTO, interface, repository and controller for Kommentar