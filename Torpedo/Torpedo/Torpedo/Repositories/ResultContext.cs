using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torpedo.Model;

namespace Torpedo.Repositories
{
    public class ResultContext : DbContext
    {
        public DbSet<Result> Eredmenyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=TorpedoDb;Integrated Security=True;");
        }
    }
}
