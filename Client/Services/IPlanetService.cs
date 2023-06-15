using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Client.Services
{
	public interface IPlanetService
	{
		Task<ICollection<Planet>> GetPlanetsAsync();
		Task<Planet> GetPlanetAsync(Guid id);
	}
}
