using System.Drawing;

namespace NotAStarWarsSim.Shared
{
	public class Planet
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public Player? Owner { get; set; }
		public Point Location { get; set; }
	}
}