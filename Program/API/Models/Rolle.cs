namespace FilmAnmeldelseApi.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Rolle
{
    public int FilmId { get; set; }
    public string Rollenavn { get; set; } = null!;
    
    //Alt herunder er database relation
    public Film Film { get; set; } = null!;
    public ICollection<SkuespillerRolle> SkuespillerRolles { get; set; }
}
