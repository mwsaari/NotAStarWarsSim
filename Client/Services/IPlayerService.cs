using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Client.Services
{
	public interface IPlayerService
	{
		ICollection<Player> Players { get; }

		Task GetPlayersAsync();
		Task<Player> GetPlayerAsync(Guid id);
		Task CreatePlayerAsync(Player player);
		Task UpdatePlayerAsync(Player player);
		Task DeletePlayerAsync(Guid id);
	}
}
