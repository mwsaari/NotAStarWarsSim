using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Client.Services
{
    public interface IPlayerService
    {
        Task<ICollection<Player>> GetPlayersAsync();
        Task<Player> GetPlayerAsync(Guid id);
        Task CreatePlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(Guid id);
    }
}
