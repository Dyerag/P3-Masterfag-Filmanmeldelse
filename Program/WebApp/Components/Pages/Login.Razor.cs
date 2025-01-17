using Microsoft.JSInterop;
using WebApp.Authentication;

namespace WebApp.Components.Pages
{
    public partial class Login
    {
        private bool isDisable { get; set; }
        private string Brugernavn { get; set; } = string.Empty;
        private string Adgangskode { get; set; } = string.Empty;
        private string Message { get; set; } = string.Empty;

        private async Task OnClickLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Brugernavn) || string.IsNullOrWhiteSpace(Adgangskode))
                {
                    Message = "Brugernavn og adgangskode må ikke være tomme.";
                    return;
                }

                var loginDto = new
                {
                    brugernavn = Brugernavn,
                    adgangskode = Adgangskode
                };

                this.isDisable = true;

                var response = await Http.PostAsJsonAsync("api/Login/login", loginDto);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();

                    // Gem JWT-token i sessionStorage
                    await JSRuntime.InvokeVoidAsync("sessionStorage.setItem", "authToken", token);

                    // Marker brugeren som autentificeret
                    var authProvider = (CustomAuthenticationStateProvider)AuthStateProvider;
                    authProvider.MarkUserAsAuthenticated(Brugernavn);


                    Message = "Login succesfuldt!";
                    StateHasChanged();
                    await Task.Delay(5000);
                    NavigationManager.NavigateTo("/"); // Naviger til hovedsiden
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Message = $"Login fejlede: {error}";
                }
            }
            catch (Exception ex)
            {
                Message = $"Fejl: {ex.Message}";
            }
            finally
            {
                isDisable = false;
            }
        }
    }


}
