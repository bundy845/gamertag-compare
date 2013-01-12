using System.Collections.Generic;

namespace Model
{
    public class GamesPlayed
    {
        public GamerInfo Info { get; set; }
        public List<Game> Games { get; set; }


        public GamesPlayed()
        {
            Games = new List<Game>();
        }
    }
}
