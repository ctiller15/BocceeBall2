using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BocceeBall_02.Context;
using System.Data.Entity;

namespace BocceeBall_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BocceeBallContext();

            //var game1 = new Models.Game()
            //{
            //    HomeScore = 0,
            //    AwayScore = 10,
            //    Notes = "Total curbstomp",
            //    DateHappened = new DateTime(2008, 10, 20)                
            //};

            //var game2 = new Models.Game()
            //{
            //    HomeScore = 10,
            //    AwayScore = 0,
            //    Notes = "GO HOME!!!",
            //    DateHappened = new DateTime(2080, 05, 23),
            //};

            //var game3 = new Models.Game()
            //{
            //    HomeScore = 5,
            //    AwayScore = 10,
            //    Notes = "Closer!",
            //    DateHappened = new DateTime(2011, 02, 14)
            //};

            //var team3 = new Models.Team()
            //{
            //    Mascot = "HoneyBadger",
            //    Color = "Orange"
            //};

            //var player3 = new Models.Player()
            //{
            //    FullName = "Chris",
            //    NickName = "Sabrina Consuelo",
            //    ThrowingArm = "Yes"
            //};

            //player3.Team = team3;
            //game3.HomeTeam = team3;
            //game3.Winner = team3;

            //var team2 = db.Teams.First(x => x.ID == 2);
            //game3.AwayTeam = team2;

            //db.Games.Add(game3);
            //db.Teams.Add(team3);
            //db.Players.Add(player3);

            //db.Games.Add(game1);
            //db.Games.Add(game2);

            // Creating some players.

            //var newPlayer = new Models.Player()
            //{
            //    FullName = "Ricardo",
            //    NickName = "Ricky",
            //    ThrowingArm = "Right"
            //};

            //var newPlayer2 = new Models.Player()
            //{
            //    FullName = "Stephanie",
            //    NickName = "Steph",
            //    ThrowingArm = "Both"
            //};

            //db.Players.Add(newPlayer);
            //db.Players.Add(newPlayer2);

            // Creating some teams.
            //var team1 = new Models.Team()
            //{
            //    Mascot = "Wolves",
            //    Color = "Gray"
            //};

            //var team2 = new Models.Team()
            //{
            //    Mascot = "Warriors",
            //    Color = "Gold"
            //};

            //db.Teams.Add(team1);
            //db.Teams.Add(team2);

            //var playerSteph = db.Players.First(p => p.FullName == "Stephanie");
            //var stephTeam = db.Teams.First(t => t.Mascot == "Wolves");

            //playerSteph.Team = stephTeam;

            //var allTeams = db.Teams.Include(x => x.Game.Where(y => y.WinnerID == x.ID));
            //foreach(var Team in allTeams)
            //{
            //    Console.WriteLine(Team.Game);

            //}

            var allTeams = db.Teams;
            var allGames = db.Games;

            var teamsWithGames = db.Teams.Include(i => i.Game).ToList();
            foreach(var team in teamsWithGames)
            {
                int WinCount = team.Game.Count(x => x.WinnerID == team.ID);
                int TotalCount = team.Game.Count();
                Console.WriteLine(team.Game.Count(x => x.WinnerID == team.ID));
                Console.WriteLine($"The {team.Color} {team.Mascot} won {WinCount} games and lost {TotalCount - WinCount} games");
            }

            //var joined = from t1 in db.Teams
            //             join t2 in db.Games on t1.ID equals t2.WinnerID
            //             select new { t1.ID, t1.Mascot, t2.WinnerID };

            //foreach(var game in joined)
            //{
            //    Console.WriteLine(game.WinnerID);
            //    Console.WriteLine($"team {game.ID} has played{joined.Count()} games");
            //}


            //foreach(var team in allTeams)
            //{
            //    var teamID = team.ID;
            //    Console.WriteLine(team.ID);
            //    Console.WriteLine(allGames.Count());
            //    var count = allGames.Count(g => teamID > 0);
            //    Console.WriteLine($"{count} games won by team {team.ID}");
            //}

            Console.ReadLine();

            var playerRicky = db.Players.First(p => p.FullName == "Ricardo");
            var rickTeam = db.Teams.First(t => t.Mascot == "Warriors");
            playerRicky.Team = rickTeam;

            // Get all games that happened in the past.
            var pastGames = db.Games.Where(x => x.DateHappened < DateTime.Today);

            foreach(var game in pastGames)
            {
                Console.WriteLine($"game {game.ID} happened on {game.DateHappened}");
            }

            // Get all games that will happen in the future.
            var futureGames = db.Games.Where(x => x.DateHappened > DateTime.Today);

            foreach(var game in futureGames)
            {
                Console.WriteLine($"game {game.ID} happens on {game.DateHappened}");
            }

            // Get all players and their team.
            var players = db.Players;

            foreach(var player in players)
            {
                Console.WriteLine($"{player.FullName} is on team {(player.TeamID != null ? player.TeamID.ToString() : "No team")}");
            }

            Console.ReadLine();
            db.SaveChanges();
        }
    }
}
