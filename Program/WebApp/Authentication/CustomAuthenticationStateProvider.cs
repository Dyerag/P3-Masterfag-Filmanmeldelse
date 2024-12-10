using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace WebApp.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private bool _hasCheckedToken = false;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!_hasCheckedToken)
            {
                // Returner anonym bruger under prerendering
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            string? token = null;
            try
            {
                token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
            }
            catch (JSException)
            {
                // Ignorer fejl under prerendering
            }

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = CreateClaimsIdentityFromToken(token);
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void MarkUserAsLoggedOut()
        {
            var identity = new ClaimsIdentity();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        private ClaimsIdentity CreateClaimsIdentityFromToken(string token)
        {
            // Forenklet parsing af token, erstat med reel JWT-parsing
            var username = token; // Simpelt eksempel: token som brugernavn
            return new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "jwt");
        }

        public void CompleteTokenCheck()
        {
            if (!_hasCheckedToken)
            {
                _hasCheckedToken = true;
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }
        }

        
    }
}
