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

            db.SaveChanges();
        }
    }
}
