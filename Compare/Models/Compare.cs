using System.Collections.Generic;
using Model;

namespace Site.Models
{
    public class Compare
    {
        public List<CompareSummary> Genre { get; set; }
        public GamerTag Player1 { get; private set; }
        public GamerTag Player2 { get; private set; }
        public List<GameCompare> Games { get; set; }
        public CompareSummary TwoYear { get; set; }
        public List<GameCompare> TwoYearGames { get; set; } 

        public Compare()
        {
            Games = new List<GameCompare>();
            Genre = new List<CompareSummary>();
            Player1 = new GamerTag();
            Player2 = new GamerTag();
        }
    }

    public class CommonGames
    {
        public Game Player1 { get; set; }
        public Game Player2 { get; set; }
    }
}