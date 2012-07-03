using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Compare
    {
        public List<GenreSummary> Genre { get; set; }
        public GamerTag Player1 { get; set; }
        public GamerTag Player2 { get; set; }
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