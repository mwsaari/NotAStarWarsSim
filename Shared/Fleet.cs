using Utilities;

namespace NotAStarWarsSim.Shared
{
	public class Fleet
	{
		public ArrayByEnum<int, Classifications> Forces { get; } = new ArrayByEnum<int, Classifications>();

		public int Strength => Forces.Sum();

		public enum Classifications
		{
			Bomber,
			Fighter,
			Corvette,
			Frigate,
			Cruiser,
			Battleship,
			Dreadnaught
		}
	}
}
