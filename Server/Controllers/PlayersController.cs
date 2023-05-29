using Microsoft.AspNetCore.Mvc;
using NotAStarWarsSim.Server.Data;
using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly DataContext _context = DataContext.Instance;

		[HttpGet]
		public ActionResult<ICollection<Player>> GetPlayers()
		{
			return Ok(GetPlayersAsync());
		}

		[HttpGet("{Id}")]
		public ActionResult<Player> GetPlayer(Guid Id)
		{
			var dbUser = GetPlayerAsync(Id);
			if (dbUser == null) { return NotFound("Player not found."); }

			return Ok(dbUser);
		}

		[HttpPost]
		public ActionResult<ICollection<Player>> CreatePlayer(Player player)
		{
			_context.Players.Add(player);

			return Ok(GetPlayersAsync());
		}

		[HttpDelete("{Id}")]
		public ActionResult<ICollection<Player>> DeletePlayer(Guid Id)
		{
			var dbPlayer = GetPlayerAsync(Id);
			if (dbPlayer == null) { return NotFound("Player not found."); }

			_context.Players.Remove(dbPlayer);

			//_context.SaveChanges();
			return Ok(GetPlayersAsync());
		}

		private Player? GetPlayerAsync(Guid Id)
		{
			return _context.Players.FirstOrDefault(player => player.Id == Id);
		}

		private ICollection<Player> GetPlayersAsync()
		{
			return _context.Players.ToList();
		}
	}
}
