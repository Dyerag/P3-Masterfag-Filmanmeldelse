using FilmAnmeldelseApi.Dto;

namespace WebApp.Services
{
    public class FilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public async Task<List<FilmDto>> GetLatestFilmsAsync()
        //{
        //    var films = await _httpClient.GetFromJsonAsync<List<FilmDto>>($"api/Film/RandomFilms/{8}");
        //    return films ?? new List<FilmDto>();
        //}
        public async Task<List<FilmDto>> GetLatestFilmsAsync(int maxRetries = 1)
        {
            int retries = 0;
            while (retries < maxRetries)
            {
                try
                {
                    // Udfør API-anmodningen
                    var films = await _httpClient.GetFromJsonAsync<List<FilmDto>>($"api/Film/RandomFilms/8");
                    if (films != null)
                    {
                        return films; // Returner resultater, hvis anmodningen lykkes
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}. Forsøger igen... ({retries + 1}/{maxRetries})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Uventet fejl: {ex.Message}");
                    break; // Hvis der opstår en anden fejl, stop retries
                }

                // Vent lidt tid før næste forsøg
                await Task.Delay(1000);
                retries++;
            }

            // Hvis alle forsøg mislykkes
            Console.WriteLine("Kunne ikke fuldføre anmodningen efter flere forsøg.");
            return new List<FilmDto>(); // Returner en tom liste som fallback
        }
        //public async Task<Queue<FilmDto>> GetTwoUniqueRandomFilmsAsync()
        //{
        //    Queue<FilmDto> randomFilms = new (await _httpClient.GetFromJsonAsync<List<FilmDto>>($"api/Film/RandomFilms/{2}"));
        //    return randomFilms;
        //}
        public async Task<Queue<FilmDto>> GetTwoUniqueRandomFilmsAsync(int maxRetries = 1)
        {
            int retries = 0;
            while (retries < maxRetries)
            {
                try
                {
                    // Udfør API-anmodningen
                    var randomFilmsList = await _httpClient.GetFromJsonAsync<List<FilmDto>>("api/Film/RandomFilms/2");
                    if (randomFilmsList != null)
                    {
                        Queue<FilmDto> randomFilms = new Queue<FilmDto>(randomFilmsList);
                        return randomFilms; // Returner resultater, hvis anmodningen lykkes
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}. Forsøger igen... ({retries + 1}/{maxRetries})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Uventet fejl: {ex.Message}"); 
                    break; // Hvis der opstår en anden fejl, stop retries
                }
                
                // Vent lidt tid før næste forsøg
                await Task.Delay(1000);
                retries++;
            }

            // Hvis alle forsøg mislykkes
            Console.WriteLine("Kunne ikke fuldføre anmodningen efter flere forsøg.");
            return new Queue<FilmDto>(); // Returner en tom kø som fallback
        }
    }
}
