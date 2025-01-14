namespace FilmAnmeldelseApi.Dto
{
    //TODO hvorfor har du lavet både loginDto og OpretDto? de gør det samme
    public class LoginDto
    {
        public string Brugernavn { get; set; } = null!;

        public string Adgangskode { get; set; } = null!;
    }
}
