using System;
using System.Linq;
using System.Web.Mvc;
using Site.Models;
using Model;

namespace Site.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Index(string tag1, string tag2)
        {

            return Compare(tag1, tag2);
        }

        [HttpPost]
        public bool ValidateUser(string tag)
        {
            var fs = new FeedService();
            return fs.GamerExists(tag);
        }

        //        
        public ActionResult Compare(string tag1, string tag2)
        {
            var fs = new FeedService();
            var c = new Compare {Player1 = {Name = tag1}, Player2 = {Name = tag2}};
            c.Player1.Valid = fs.GamerExists(tag1);
            c.Player2.Valid = fs.GamerExists(tag2);

            if (c.Player1.Valid &&
                c.Player2.Valid)
            {
                c.Player1.Valid = true;
                c.Player2.Valid = true;

                var tag1Games = fs.GamesPlayed(tag1);
                var tag2Games = fs.GamesPlayed(tag2);

                c.Player1.TotalScore = tag1Games.Games.Sum(a => a.currentgs);
                c.Player2.TotalScore = tag2Games.Games.Sum(a => a.currentgs);

                var common = tag1Games.Games.Join(tag2Games.Games, a => a.id, b => b.id, (a, b) => new { Player1 = a, Player2 = b })
                                            .Where(a => a.Player1.currentgs > 0 && a.Player2.currentgs > 0)
                                            .OrderByDescending(a => Convert.ToDateTime(a.Player1.lastplayed));


                var genres = common.Select(a => a.Player1.genre).Distinct();
                var totalWins = 0;
                var totalTies = 0;
                var totalLoses = 0;
                var totalTag1Score = 0;
                var totalTag2Score = 0;
                foreach (var genre in genres)
                {
                    var genre1 = genre;
                    var genreGames = common.Where(a => a.Player1.genre == genre1).ToList();
                    var total = genreGames.Count();
                    var wins = genreGames.Count(a => a.Player1.currentgs > a.Player2.currentgs);
                    var ties = genreGames.Count(a => a.Player1.currentgs == a.Player2.currentgs);
                    var loses = total - wins - ties;
                    var genreSummary = new GenreSummary
                        {
                        Genre = genre,
                        Wins = wins,
                        Ties = ties,
                        Loses = loses,
                        Tag1Score = genreGames.Sum(a => a.Player1.currentgs),
                        Tag2Score = genreGames.Sum(a => a.Player2.currentgs)
                    };

                    c.Genre.Add(genreSummary);

                    totalWins += wins;
                    totalLoses += loses;
                    totalTies += ties;
                    totalTag1Score += genreSummary.Tag1Score;
                    totalTag2Score += genreSummary.Tag2Score;
                }

                // can we do in one pass instead of N?
                c.Genre.Add(new GenreSummary
                    {
                    Genre = "All",
                    Wins = totalWins,
                    Ties = totalTies,
                    Loses = totalLoses,
                    Tag1Score = totalTag1Score,
                    Tag2Score = totalTag2Score
                    
                });

                c.Genre = c.Genre.OrderByDescending(a => a.Tag1Score)
                                 .ToList();

                c.Games = common.ToList().ConvertAll(a => new GameCompare
                {
                    Name = a.Player1.name,
                    Id = a.Player1.id,
                    Tile = a.Player1.tile,
                    Tile64 = a.Player1.tile64,
                    Tag1Score = a.Player1.currentgs,
                    Tag2Score = a.Player2.currentgs,
                    Genre = a.Player1.genre,
                    Difference = a.Player1.currentgs - a.Player2.currentgs,
                    LastPayed =  DateTime.Parse(a.Player1.lastplayed)
                });
            }

            return View("Compare",c);
        }

     

    }
}
