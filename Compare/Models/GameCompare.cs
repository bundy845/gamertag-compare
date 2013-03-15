using System;

namespace Site.Models
{
    public class GameCompare
    {
        public string Name { get; set; }
        public string Tile { get; set; }
        public string Tile64 { get; set; }
        public string Id { get; set; }
        public int Tag1Score { get; set; }
        public int Tag2Score { get; set; }
        public string Genre { get; set; }
        public int Difference { get; set; }
        public DateTime LastPayed { get; set; }
    }
}