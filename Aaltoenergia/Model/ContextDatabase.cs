using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaltoenergia.Model
{
    public class ContextDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-J3NOIFB9\SQLEXPRESS01;Database=Aaltoenergia;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.PersonalSubscription)
                .WithOne(ps => ps.Client)
                .HasForeignKey<PersonalSubscription>(ps => ps.ClientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalSubscription>()
                .HasOne(ps => ps.Client)
                .WithOne(c => c.PersonalSubscription)
                .HasForeignKey<PersonalSubscription>(c => c.ClientID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PersonalSubscription>()
                .HasOne(ps => ps.Payment)
                .WithOne(p => p.PersonalSubscription)
                .HasForeignKey<PersonalSubscription>(p => p.PaymentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(ps => ps.PersonalSubscription)
                .WithOne(c => c.Payment)
                .HasForeignKey<PersonalSubscription>(c => c.PaymentID)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Payment> payment { get; set; } = null!;
        public void AddPayment(DateTime date, decimal sum, string typeOfPayment,
            int personalSubscriptionID)
        {
            var newPayment = new Payment
            {
                Date = date,
                Sum = sum,
                TypeOfPayment = typeOfPayment,
                PersonalSubscriptionID = personalSubscriptionID
            };
            payment.Add(newPayment);
            SaveChanges();
        }

        public DbSet<PersonalSubscription> personalSubscription { get; set; } = null!;
        public void AddPersonalSubscription(int subscriptionID, int paymentID, int clientID)
        {
            var newPersonalSubscription = new PersonalSubscription
            {
                SubscriptionID = subscriptionID,
                PaymentID = paymentID,
                ClientID = clientID
            };
            personalSubscription.Add(newPersonalSubscription);
            SaveChanges();
        }

        public DbSet<Subscription> subscription { get; set; } = null!;
        public void AddSubscription(decimal cost, string duration, int subscriptionTypeID)
        {
            var newSubscription = new Subscription
            {
                Cost = cost,
                Duration = duration,
                SubscriptionTypeID = subscriptionTypeID
            };
            subscription.Add(newSubscription);
            SaveChanges();
        }

        public DbSet<SubscriptionType> subscriptionType { get; set; } = null!;
        public void AddSubscriptionType(string name)
        {
            var newSubscriptionType = new SubscriptionType
            {
                Name = name
            };
            subscriptionType.Add(newSubscriptionType);
            SaveChanges();
        }

        public DbSet<Trainer> trainer { get; set; } = null!;
        public void AddTrainer(string lName, string fName, string pName,
            DateTime bDate, int passportNumber, int passportSeries, int experience, string achievements,
            string phone, string password, string login)
        {
            var newTrainer = new Trainer
            {
                LName = lName,
                FName = fName,
                PName = pName,
                BDate = bDate,
                PassportNumber = passportNumber,
                PassportSeries = passportSeries,
                Experience = experience,
                Achievements = achievements,
                Phone = phone,
                Password = password,
                Login = login,
            };
            trainer.Add(newTrainer);
            SaveChanges();
        }

        public DbSet<Visiting> visiting { get; set; } = null!;
        public void AddVisiting(DateTime date, DateTime startTime, DateTime endTime, int clientID)
        {
            var newVisiting = new Visiting
            {
                Date = date,
                StartTime = startTime,
                EndTime = endTime,
                ClientID = clientID
            };
            visiting.Add(newVisiting);
            SaveChanges();
        }

        public DbSet<Workout> workout { get; set; } = null!;
        public void AddWorkout(DateTime startTime, DateTime endTime, string dayOfTheWeek,
            int locationOfTheEvent, int workoutTypeID, int trainerID)
        {
            var newWorkout = new Workout
            {
                StartTime = startTime,
                EndTime = endTime,
                DayOfTheWeek = dayOfTheWeek,
                LocationOfTheEvent = locationOfTheEvent,
                WorkoutTypeID = workoutTypeID,
                TrainerID = trainerID
            };
            workout.Add(newWorkout);
            SaveChanges();
        }

        public DbSet<WorkoutType> workoutType { get; set; } = null!;
        public void AddWorkoutType(string name)
        {
            var newWorkoutType = new WorkoutType
            {
                Name = name
            };
            workoutType.Add(newWorkoutType);
            SaveChanges();
        }

        public DbSet<Client> client { get; set; } = null!;
        public void AddClient(string lName, string fName, string pName,
            DateTime bDate, int passportNumber, int passportSeries, string phone, string password, int personalSubscriptionID)
        {
            var newClient = new Client
            {
                LName = lName,
                FName = fName,
                PName = pName,
                BDate = bDate,
                PassportNumber = passportNumber,
                PassportSeries = passportSeries,
                Phone = phone,
                Password = password,
                PersonalSubscriptionID = personalSubscriptionID
            };
            client.Add(newClient);
            SaveChanges();
        }

        public DbSet<ClientWorkout> сlientWorkout { get; set; } = null!;
        public void AddClientWorkout(int clientID, int workoutID)
        {
            var newClientWorkout = new ClientWorkout
            {
                ClientID = clientID,
                WorkoutID = workoutID
            };
            сlientWorkout.Add(newClientWorkout);
            SaveChanges();
        }
    }
}