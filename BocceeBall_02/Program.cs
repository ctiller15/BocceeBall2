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


            Console.ReadLine();
            db.SaveChanges();
        }
    }
}
