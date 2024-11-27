namespace FilmAnmeldelseApi.Models
{
    public class FilmDirektør
    {
        public int FilmId { get; set; }
        public int DirektørId { get; set; }

        //Alt herunder er database relation
        public Film ?Film { get; set; }
        public Direktør ?Direktør { get; set; }
    }
}
