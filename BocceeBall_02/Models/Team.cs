﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceeBall_02.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Mascot { get; set; }
        public string Color { get; set; }

        public ICollection<Game> Game { get; set; } = new HashSet<Game>();

    }
}
