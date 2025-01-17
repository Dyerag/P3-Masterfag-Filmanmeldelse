namespace Api.Models
{
    public class FilmForfatter
    {
        public int FilmId { get; set; }
        public int ForfatterId { get; set; }

        // Past this point is database Relations
        public Film Film { get; set; }
        public Forfatter Forfatter { get; set; }
    }
}
