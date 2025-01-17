using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    public partial class Map
    {
        /// <summary>
        /// Creates a dto for Anmeldelse.
        /// </summary>
        /// <param name="anmeldelse"></param>
        /// <returns>The newly created dto.</returns>
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
        /// Creates a list of DTOs for Anmeldelse.
        /// </summary>
        /// <param name="anmeldelser"></param>
        /// <returns>The list of DTOs.</returns>
        public static List<AnmeldelseDto> ToDto(IEnumerable<Anmeldelse> anmeldelser)
        {
            List<AnmeldelseDto> dtoList = new();

            Parallel.ForEach(anmeldelser, i =>
            {
                dtoList.Add(ToDto(i));
            });

            return dtoList;
        }
    }
}
