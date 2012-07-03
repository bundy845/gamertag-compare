using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class GenreSummary
    {
        public string Genre { get; set; }
        public int Tag1Score { get; set; }
        public int Tag2Score { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }

    }
}