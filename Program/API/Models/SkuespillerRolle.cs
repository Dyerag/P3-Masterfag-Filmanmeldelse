namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class SkuespillerRolle
{
    public int FilmId { get; set; }
    public string Rollenavn { get; set; } = null!;
    public int SkuespillerId { get; set; }
    //Om det er en fysisk skuespiller eller en stemmeskuespiller
    public string RolleType { get; set; } = null!;

    //Alt herunder er database relation
    public Rolle Rolle { get; set; } = null!;
    public Skuespiller Skuespiller { get; set; } = null!;
}
