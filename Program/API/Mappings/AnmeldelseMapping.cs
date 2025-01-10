using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    public partial class Map
    {
        public static AnmeldelseDto ToDto(Anmeldelse anmeldelse) => new AnmeldelseDto
        {
            FilmId = anmeldelse.FilmId,
            AnmelderId= anmeldelse.AnmelderId,
            Titel = anmeldelse.Titel,
            Begrundelse = anmeldelse.Begrundelse,
            Bedømmelse = anmeldelse.Bedømmelse,
            Anmeldsdato = anmeldelse.Anmeldsdato
        };

        public static List<AnmeldelseDto> ToDto(IEnumerable<Anmeldelse> Anmeldelser) => (List<AnmeldelseDto>)Anmeldelser.Select(ToDto);
    }
}
