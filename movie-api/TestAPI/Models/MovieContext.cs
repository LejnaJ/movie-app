using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cast> Cast { get; set; }
    }
}
