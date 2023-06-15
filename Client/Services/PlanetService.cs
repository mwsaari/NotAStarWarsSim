using NotAStarWarsSim.Shared;
using System.Net.Http.Json;

namespace NotAStarWarsSim.Client.Services
{
	public class PlanetService : IPlanetService
	{
		private readonly HttpClient _http;

		public PlanetService(HttpClient http)
		{
			_http = http;
		}

		public async Task<ICollection<Planet>> GetPlanetsAsync()
		{
			var result = await _http.GetFromJsonAsync<ICollection<Planet>>($"api/planets");
			if (result is not null)
			{
				return result;
			}
			throw new Exception("Unknown Error");
		}

		public async Task<Planet> GetPlanetAsync(Guid id)
		{
			var result = await _http.GetFromJsonAsync<Planet>($"api/planet/{id}");
			if (result is not null)
			{
				return result;
			}
			throw new Exception("Player not found");
		}
	}
}
