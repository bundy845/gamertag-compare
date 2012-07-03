using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GamesPlayed
    {
        public GamerInfo info { get; set; }
        public List<Game> Games { get; set; }


        public GamesPlayed()
        {
            Games = new List<Game>();
        }
    }
}
