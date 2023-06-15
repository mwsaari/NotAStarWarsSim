using Microsoft.AspNetCore.Mvc;
using NotAStarWarsSim.Server.Data;
using NotAStarWarsSim.Shared;

namespace NotAStarWarsSim.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanetsController : ControllerBase
	{
		private readonly DataContext _context = DataContext.Instance;

		[HttpGet]
		public ActionResult<ICollection<Planet>> GetPlanets()
		{
			return Ok(GetPlanetsAsync());
		}

		[HttpGet("{Id}")]
		public ActionResult<ICollection<Planet>> GetPlanet(Guid Id)
		{
			var dbUser = GetPlanetAsync(Id);
			if (dbUser == null) { return NotFound("Player not found."); }

			return Ok(dbUser);
		}

		private Planet? GetPlanetAsync(Guid Id)
		{
			return _context.Planets.FirstOrDefault(planet => planet.Id == Id);
		}

		private ICollection<Planet> GetPlanetsAsync()
		{
			return _context.Planets.ToList();
		}
	}
}
