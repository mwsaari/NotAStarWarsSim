namespace NotAStarWarsSim.Shared
{
    public class Fleet
    {
        public ArrayByEnum<int, Classifications> Forces { get; } = new ArrayByEnum<int, Classifications>();

        public int Strenght => Forces.Sum();

        public enum Classifications
        {
            Bomber,
            Fighter,
            Corvette,
            Frigate,
            Cruiser,
            Battlecruiser,
            Dreadnaught
        }
    }
}
