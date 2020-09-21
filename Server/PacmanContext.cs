using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class PacmanContext : DbContext
    {
        public PacmanContext(DbContextOptions<PacmanContext> options) : base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ghost> Ghosts { get; set; }
    }
}
