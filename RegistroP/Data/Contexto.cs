using Microsoft.EntityFrameworkCore;
using RegistroP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroP.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/RegistroP");
        }
    }
}
