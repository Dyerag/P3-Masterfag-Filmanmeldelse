namespace FilmAnmeldelseApi.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }

        public string Titel { get; set; } = null!;
        /* Temporarily made Plakat a comment, as the responce body keeps being fillede by the poster.
         * Making it difficult to check for more then one set of data */
        //public byte[] Plakat { get; set; } = null!;

        public string Synopse { get; set; } = null!;

        public int Aldersgrænse { get; set; }

        public DateOnly Udgivelsesdato { get; set; }

        public TimeOnly Spilletid { get; set; }

        public decimal Gennemsnitsanmeldelse { get; set; }
    }
}
