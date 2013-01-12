using System.Collections.Generic;

namespace Site.Models
{
    public class Compare
    {
        public List<GenreSummary> Genre { get; set; }
        public GamerTag Player1 { get; private set; }
        public GamerTag Player2 { get; private set; }
        public List<GameCompare> Games { get; set; }

        public Compare()
        {
            Games = new List<GameCompare>();
            Genre = new List<GenreSummary>();
            Player1 = new GamerTag();
            Player2 = new GamerTag();
        }
    }
}