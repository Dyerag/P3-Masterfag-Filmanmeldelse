namespace FilmAnmeldelseApi.Models
{
    public class FilmForfatter
    {
        public int FilmId { get; set; }
        public int ForfatterId { get; set; }

        //Alt herunder er database relation
        public Film ?Film { get; set; }
        public Forfatter ?Forfatter { get; set; }
    }
}
