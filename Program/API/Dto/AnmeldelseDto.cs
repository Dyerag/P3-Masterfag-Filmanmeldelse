namespace Api.Dto
{
    public class AnmeldelseDto
    {
        public int FilmId { get; set; }
        // Reviewers userId.
        public int AnmelderId { get; set; }
        public string? Titel { get; set; }
        public string? Begrundelse { get; set; }
        // 1 - 5 Stars.
        public int Bedømmelse { get; set; }
        // When the review was made. Is given automaticaly by the database.
        public DateOnly Anmeldsdato { get; set; }
    }
}
