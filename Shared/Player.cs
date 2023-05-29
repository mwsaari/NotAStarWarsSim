namespace NotAStarWarsSim.Shared
{
	public class Player
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public int Password { get; set; }

		public ICollection<Planet> Planets { get; } = new List<Planet>();
	}
}