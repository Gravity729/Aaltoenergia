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
        public DbSet<LoginC> loginC { get; set; } = null!;
        public DbSet<LoginT> loginT { get; set; } = null!;
        public DbSet<Payment> payment { get; set; } = null!;
        public DbSet<PersonalSubscription> personalSubscription { get; set; } = null!;
        public DbSet<Subscription> subscription { get; set; } = null!;
        public DbSet<SubscriptionType> subscriptionType { get; set; } = null!;
        public DbSet<Trainer> trainer { get; set; } = null!;
        public DbSet<Visiting> visiting { get; set; } = null!;
        public DbSet<Workout> workout { get; set; } = null!;
        public DbSet<WorkoutType> workoutType { get; set; } = null!;
        public DbSet<Client> client { get; set; } = null!;
    }
}
