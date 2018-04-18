using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceeBall_02.Models
{
    public class Game
    {
        public int ID { get; set; }

        // One team to many games.
        public int? HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }

        public int? AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }

        public int? WinnerID { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime DateHappened { get; set; }
        public string Notes { get; set; }
    }
}
