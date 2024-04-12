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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.LoginC)
                .WithOne(l => l.Client)
                .HasForeignKey<LoginC>(l => l.ClientID)
                .OnDelete(DeleteBehavior.NoAction); 
            
            modelBuilder.Entity<LoginC>()
                .HasOne(l => l.Client)
                .WithOne(c => c.LoginC)
                .HasForeignKey<LoginC>(l => l.ClientID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Client>()
                .HasOne(c => c.PersonalSubscription)
                .WithOne(ps => ps.Client)
                .HasForeignKey<PersonalSubscription>(ps => ps.ClientID)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<PersonalSubscription>()
                .HasOne(ps => ps.Client)
                .WithOne(c => c.PersonalSubscription)
                .HasForeignKey<PersonalSubscription>(c => c.ClientID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PersonalSubscription>()
                .HasOne(ps => ps.Payment)
                .WithOne(p => p.PersonalSubscription)
                .HasForeignKey<Payment>(p => p.PaymentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(ps => ps.PersonalSubscription)
                .WithOne(c => c.Payment)
                .HasForeignKey<Payment>(c => c.PaymentID)
                .OnDelete(DeleteBehavior.Restrict);
            // Убедитесь, что все связи имеют явно указанные действия при удалении или обновлении

            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.LoginT)
                .WithOne(l => l.Trainer)
                .HasForeignKey<LoginT>(l => l.TrainerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LoginT>()
                .HasOne(ps => ps.Trainer)
                .WithOne(c => c.LoginT)
                .HasForeignKey<LoginT>(c => c.TrainerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        //public ContextDatabase()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}
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
