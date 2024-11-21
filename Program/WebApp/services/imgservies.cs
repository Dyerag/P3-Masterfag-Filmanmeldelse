using WebApplicationApi.Data;
using WebApplicationApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using WebApplicationApi.Model;

namespace BlazorApp.Services
{
    public class ImageService
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ny metode til at hente de seneste 8 billeder
        //public async Task<List<Table>> GetLatestImagesAsync()
        //{
        //    var images = await _httpClient.GetFromJsonAsync<List<Table>>("api/getImage/latest");
        //    return images ?? new List<Table>();
        //}

        public async Task<List<Film>> GetLatestFilmsAsync()
        {
            var films = await _httpClient.GetFromJsonAsync<List<Film>>("api/getfilm");
            return films ?? new List<Film>();
        }

        //public async Task<Film> GetRandomLeftFilmsAsync()
        //{
        //    var randomLeftFilm = await _httpClient.GetFromJsonAsync<Film>("api/GetFilm/random/left");
        //    return randomLeftFilm;
        //}

        //public async Task<Film> GetRandomRightFilmsAsync()
        //{
        //    var randomRightFilm = await _httpClient.GetFromJsonAsync<Film>("api/GetFilm/random/right");
        //    if (GetRandomRightFilmsAsync != GetRandomLeftFilmsAsync)
        //    {

        //    }
        //    return randomRightFilm;
        //}

        public async Task<(Film RandomLeftFilm, Film RandomRightFilm)> GetTwoUniqueRandomFilmsAsync()
        {
            // Hent begge film samtidigt
            var randomLeftFilm = await _httpClient.GetFromJsonAsync<Film>("api/GetFilm/random/left");
            var randomRightFilm = await _httpClient.GetFromJsonAsync<Film>("api/GetFilm/random/right");

            // Hvis de to film er ens, hent en ny højre film
            if (randomLeftFilm != null && randomRightFilm != null && randomLeftFilm.Id == randomRightFilm.Id)
            {
                randomRightFilm = await _httpClient.GetFromJsonAsync<Film>("api/GetFilm/random/right");
            }

            return (randomLeftFilm, randomRightFilm);
        }
    }
}
