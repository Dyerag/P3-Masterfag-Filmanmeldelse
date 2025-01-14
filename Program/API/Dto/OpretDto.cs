namespace FilmAnmeldelseApi.Dto
{
    // hvorfor har du lavet både loginDto og OpretDto? de gør det samme
    public class OpretDto
    {
        public string Brugernavn { get; set; } = null!; // Krævet brugernavn
        public string Adgangskode { get; set; } = null!; // Krævet adgangskode
    }
}
