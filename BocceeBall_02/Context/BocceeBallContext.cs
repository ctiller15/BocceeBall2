using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BocceeBall_02.Models;

namespace BocceeBall_02.Context
{
    class BocceeBallContext :DbContext
    {
        public BocceeBallContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
