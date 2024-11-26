namespace FilmAnmeldelseApi.Dto
{
    public class AnmeldelseDto
    {
        public int FilmId { get; set; }
        //Anmelderens brugerId
        public int AnmelderId { get; set; }
        public string? Titel { get; set; }
        public string? Begrundelse { get; set; }
        //1 - 5 Stjerner
        public int Bedømmelse { get; set; }
        //hvornår anmeldelsen blev givet. fås automatisk
        public DateOnly Anmeldsdato { get; set; }
    }
}
