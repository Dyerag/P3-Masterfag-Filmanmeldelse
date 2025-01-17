namespace Api.Models
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        /* Genre has a number at the end, because the property responsible for the relation
         * between the Genre table and this table, is named Genre. It's gets corrected by Fluent API*/
        /* Properties responsible for database relations,
         * must always share a name with the table on the other end of the relation*/
        public string Genre1 { get; set; } = null!;

        //Todo finish rewritting the comments from here
        //Alt herunder er database relation
        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}
