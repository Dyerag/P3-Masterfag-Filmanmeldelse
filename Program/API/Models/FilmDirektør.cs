namespace Api.Models
{
    public class FilmDirektør
    {
        public int FilmId { get; set; }
        public int DirektørId { get; set; }

        // Past this point is database relations
        public Film Film { get; set; }
        public Direktør Direktør { get; set; }
    }
}
