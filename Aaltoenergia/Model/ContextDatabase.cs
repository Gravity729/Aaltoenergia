using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaltoenergia.Model
{
    class ContextDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-J3NOIFB9\SQLEXPRESS01;Database=Aaltoenergia;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public ContextDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
