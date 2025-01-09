namespace Api.Models
{
    public class FilmProducer
    {
        public int FilmId { get; set; }
        public int ProducerId { get; set; }

        //Alt herunder er database relation
        public Film Film { get; set; }
        public Producer Producer { get; set; }
    }
}
