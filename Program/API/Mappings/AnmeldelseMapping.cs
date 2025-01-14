using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    public partial class Map
    {
        /// <summary>
        /// Skaber en AnmeldelseDto
        /// </summary>
        /// <param name="anmeldelse"></param>
        /// <returns>Den skabte AnmeldelseDto</returns>
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
        /// Skaber en liste af AnmeldelsesDto'er
        /// </summary>
        /// <param name="Anmeldelser"></param>
        /// <returns>Listen af AnmeldelsesDto'er</returns>
        public static List<AnmeldelseDto> ToDto(IEnumerable<Anmeldelse> Anmeldelser)
        {
            List<AnmeldelseDto> dtoListe = new();

            foreach (var i in Anmeldelser)
                dtoListe.Add(ToDto(i));

            return dtoListe;
        }
    }
}
