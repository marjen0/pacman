using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PacmanContext : DbContext
    {
        public PacmanContext(DbContextOptions<PacmanContext> options) : base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Pacman> Pacmans { get; set; }
    }
}
