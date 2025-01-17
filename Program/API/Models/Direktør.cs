namespace Api.Models;

/* Made som changes since scaffolding, to make it closer to how I would have written
 * it, if i had made it from the ground up. Removed partial, virtual and new.*/
public class Direktør
{
    public int Id { get; set; }
    public string Fuldenavn { get; set; } = null!; //null! means "Not Nullable" in the database

    //Past this point is just database relations
    public ICollection<FilmDirektør> FilmDirektørs { get; set; }
}
//todo make a DTO, interface, repository and controller for Direktør