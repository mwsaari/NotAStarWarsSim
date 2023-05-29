using Microsoft.AspNetCore.Components;
using NotAStarWarsSim.Shared;
using System.Net.Http.Json;

namespace NotAStarWarsSim.Client.Services
{
	public class PlayerService : IPlayerService
	{
		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

		public ICollection<Player> Players { get; set; } = new List<Player>();

		public PlayerService(HttpClient http, NavigationManager navigationManager)
		{
			_http = http;
			_navigationManager = navigationManager;
		}

		public async Task GetPlayersAsync()
		{
			var result = await _http.GetFromJsonAsync<ICollection<Player>>($"api/players");
			if (result is not null)
			{
				Players = result;
				return;
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
			await SetUniversesFromResult(result);
			_navigationManager.NavigateTo("player");
		}

		public async Task UpdatePlayerAsync(Player player)
		{
			var result = await _http.PutAsJsonAsync($"api/players/{player.Id}", player);
			await SetUniversesFromResult(result);
			_navigationManager.NavigateTo("player");
		}

		public async Task DeletePlayerAsync(Guid id)
		{
			var result = await _http.DeleteAsync($"api/players/{id}");
			await SetUniversesFromResult(result);
			_navigationManager.NavigateTo("player");
		}

		private async Task SetUniversesFromResult(HttpResponseMessage reponseMessage)
		{
			var response = await reponseMessage.Content.ReadFromJsonAsync<ICollection<Player>>();
			if (response != null)
			{
				Players = response;
				return;
			}
			throw new Exception("Unknown Error");
		}
	}
}
