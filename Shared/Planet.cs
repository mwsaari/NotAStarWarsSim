using System.Drawing;
using Utilities;

namespace NotAStarWarsSim.Shared
{
    public class Planet
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public Player? Owner { get; set; }
        public Point Location { get; set; }

        public ArrayByEnum<int, StructureTypes> Structures { get; } = new ArrayByEnum<int, StructureTypes>();

        public enum StructureTypes
        {
            Infrastructure,
            Mines,
            OfficerAcademy,
            FighterYard,
            CorvetteYard,
            FrigateYard,
            CruiserYard,
            BattleshipYard,
            DreadnaughtYard
        }
    }
}