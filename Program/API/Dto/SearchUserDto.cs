namespace FilmAnmeldelseApi.Dto
{
    public class SearchUserDto
    {
        public int Id { get; set; }
        public string Brugernavn { get; set; } = null!;
        public byte[]? Billede { get; set; }
    }
}
