using System;
using System.Collections.Generic;
using System.Linq;

namespace Site.Models
{
    public class CompareSummary
    {
        public string Label { get; set; }
        public int Tag1Score { get; set; }
        public int Tag2Score { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public DateTime MostRecentDate { get; set; }
        public string LabelSort { get { return Label == "All" ? "aaaaaaaaaaaaaa" : Label; } }

        public static CompareSummary Map(IEnumerable<CommonGames> games, string label)
        {
            var total = games.Count();
            var wins = games.Count(a => a.Player1.currentgs > a.Player2.currentgs);
            var ties = games.Count(a => a.Player1.currentgs == a.Player2.currentgs);
            var loses = total - wins - ties;
            return new CompareSummary
            {
                Label = label,
                Wins = wins,
                Ties = ties,
                Loses = loses,
                Tag1Score = games.Sum(a => a.Player1.currentgs),
                Tag2Score = games.Sum(a => a.Player2.currentgs)
            };
           
        }
    }
}