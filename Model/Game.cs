using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Game
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        public string tid { get; set; }
        public string titleid { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string gametype { get; set; }
        public string url { get; set; }
        public int currentgs { get; set; }
        public int totalgs { get; set; }
        public int currentach { get; set; }
        public int totalach { get; set; }
        public double percentcomplete { get; set; }
        public string tile { get; set; }
        public string tile64 { get; set; }
        public int days { get; set; }
        public string lastplayed { get; set; }
        public string own { get; set; }
        
    }
}
