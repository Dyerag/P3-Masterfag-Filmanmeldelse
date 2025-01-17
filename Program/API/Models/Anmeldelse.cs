namespace Api.Models;

/* Made som changes since scaffolding, to make it closer to how I would have written
 * it, if i had made it from the ground up. Removed partial, virtual and new.*/
public class Anmeldelse
{
    //The ID to the film this review belongs to.
    public int FilmId { get; set; }
    //The reviewers userID.
    public int AnmelderId { get; set; }
    public string? Titel { get; set; }
    public string? Begrundelse { get; set; }
    //1 - 5 Stars.
    public int Bedømmelse { get; set; }
    // The date the review was made. Automaticaly given by the database upon storing.
    public DateOnly Anmeldsdato { get; set; }

    // Everything past this point, is database relations.
    public User Anmelder { get; set; } = null!; //null! means not nullable in Database.
    public Film Film { get; set; } = null!;
    public ICollection<Kommentar> Kommentars { get; set; } = [];
}