namespace FilmAnmeldelseApi.Dto
{
    public class SearchFilmDto
    {
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public byte[] Plakat { get; set; } = null!;
    }
}
