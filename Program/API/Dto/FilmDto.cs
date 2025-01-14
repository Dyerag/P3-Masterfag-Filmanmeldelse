namespace Api.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }

        public string Titel { get; set; } = null!;

        public byte[] Plakat { get; set; } = null!;

        public string Synopse { get; set; } = null!;

        public int Aldersgrænse { get; set; }

        public DateOnly Udgivelsesdato { get; set; }

        public TimeOnly Spilletid { get; set; }

        public decimal Gennemsnitsanmeldelse { get; set; }
    }
}
