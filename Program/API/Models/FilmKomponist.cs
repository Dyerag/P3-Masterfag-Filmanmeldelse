namespace FilmAnmeldelseApi.Models
{
    public class FilmKomponist
    {
        public int FilmId { get; set; }
        public int KomponistId { get; set; }

        //Alt herunder er database relation
        public Film? Film { get; set; }
        public Komponist? Komponist { get; set; }
    }
}
