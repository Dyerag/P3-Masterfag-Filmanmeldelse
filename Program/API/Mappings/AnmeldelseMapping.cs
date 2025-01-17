using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    public partial class Map
    {
        /// <summary>
        /// Creates an AnmeldelseDto (ReviewDto).
        /// </summary>
        /// <param name="anmeldelse"></param>
        /// <returns>The newly created Dto</returns>
        public static AnmeldelseDto ToDto(Anmeldelse anmeldelse) => new AnmeldelseDto
        {
            FilmId = anmeldelse.FilmId,
            AnmelderId = anmeldelse.AnmelderId,
            Titel = anmeldelse.Titel,
            Begrundelse = anmeldelse.Begrundelse,
            Bedømmelse = anmeldelse.Bedømmelse,
            Anmeldsdato = anmeldelse.Anmeldsdato
        };

        /// <summary>
        /// Creates a list of AnmeldelseDto
        /// </summary>
        /// <param name="Anmeldelser"></param>
        /// <returns>Listen af AnmeldelsesDto'er</returns>
        public static List<AnmeldelseDto> ToDto(IEnumerable<Anmeldelse> Anmeldelser)
        {
            List<AnmeldelseDto> dtoListe = new();

            Parallel.ForEach(Anmeldelser, i =>
            {
                dtoListe.Add(ToDto(i));
            });

            return dtoListe;
        }
    }
}
