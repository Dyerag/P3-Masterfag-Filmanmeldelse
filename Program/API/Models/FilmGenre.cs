namespace FilmAnmeldelseApi.Models
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        /* Genre har et tal til sidst, fordi den property der er ansvarlig for forholdet mellem genre tabellen
         * og denne tabel, hedder genre. det rettes af Fluent API*/
        /* Properties der er ansvarlig for database relationer,
         * skal altid ha' samme navn med tabellen i den anden ende a relationen*/
        public string Genre1 { get; set; } = null!;

        //Alt herunder er database relation
        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}
