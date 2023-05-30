using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Client.Services
{
    public interface IPlanetService
    {
        Task<ICollection<Planet>> GetPlanetsAsync();
        Task<ICollection<Planet>> GetPlanetOfPlayer(Player player);
        Task<Planet> GetPlanetAsync(Guid id);
    }
}
