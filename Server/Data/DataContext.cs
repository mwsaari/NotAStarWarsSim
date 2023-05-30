using NotAStarWarsSim.Shared;
using System.Drawing;

namespace NotAStarWarsSim.Server.Data
{
    public class DataContext
    {
        public static readonly DataContext Instance = new DataContext();

        public DataContext()
        {
            SeedData();
        }

        private void SeedData()
        {
            var player1 = new Player() { Username = "Boom9001", Password = "foo".GetHashCode(), Id = Guid.NewGuid() };
            var player2 = new Player() { Username = "Stump", Password = "bar".GetHashCode(), Id = Guid.NewGuid() };
            Players.AddRange(new[] { player1, player2 });

            var planet1 = new Planet() { Owner = player1, DisplayName = "Boom's Planet", Location = new Point(1, 1), Id = Guid.NewGuid() };
            var planet2 = new Planet() { Owner = player2, DisplayName = "Stump's Planet", Location = new Point(-1, -1), Id = Guid.NewGuid() };
            var planet3 = new Planet() { Location = new Point(0, 0) };
            Planets.AddRange(new[] { planet1, planet2, planet3 });
        }

        public List<Player> Players { get; set; } = new List<Player>();
        public List<Planet> Planets { get; set; } = new List<Planet>();
    }
}
