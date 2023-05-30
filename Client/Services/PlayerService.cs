using Microsoft.AspNetCore.Components;
using NotAStarWarsSim.Shared;
using System.Net.Http.Json;

namespace NotAStarWarsSim.Client.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PlayerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public async Task<ICollection<Player>> GetPlayersAsync()
        {
            var result = await _http.GetFromJsonAsync<ICollection<Player>>($"api/players");
            if (result is not null)
            {
                return result;
            }
            throw new Exception("Unknown Error");
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            var result = await _http.GetFromJsonAsync<Player>($"api/players/{id}");
            if (result is not null)
            {
                return result;
            }
            throw new Exception("Player not found");
        }

        public async Task CreatePlayerAsync(Player player)
        {
            var result = await _http.PostAsJsonAsync("api/players", player);
            _navigationManager.NavigateTo("player");
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            var result = await _http.PutAsJsonAsync($"api/players/{player.Id}", player);
            _navigationManager.NavigateTo("player");
        }

        public async Task DeletePlayerAsync(Guid id)
        {
            var result = await _http.DeleteAsync($"api/players/{id}");
            _navigationManager.NavigateTo("player");
        }
    }
}
