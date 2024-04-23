using Aaltoenergia.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aaltoenergia
{
    public partial class App : Application
    {
        public static int UserRole;
        public static Client currentClient = null;
        public static Trainer currentTrainer = null;
        public static Subscription currentSubscription = null;
        public static Workout currentWorkout = null;

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    using (var context = new ContextDatabase())
        //    {
        //        context.AddClient("Смирнов", "Петр", "Владимирович", new DateTime(1986, 5, 23), 101010, 1010, "89101001010", "smirnov86", 1);
        //        context.AddClient("Иванов", "Иван", "Иванович", new DateTime(1990, 10, 10), 202020, 2020, "89202002020", "ivanov90", 2);
        //        context.AddClient("Петров", "Алексей", "Петрович", new DateTime(1988, 3, 15), 303030, 3030, "89303003030", "petrov88", 3);
        //        context.AddClient("Козлова", "Мария", "Андреевна", new DateTime(1995, 7, 5), 404040, 4040, "89404004040", "kozlova95", 4);
        //        context.AddClient("Сидоров", "Антон", "Сергеевич", new DateTime(1982, 12, 20), 505050, 5050, "89505005050", "sidorov82", 5);

        //        context.AddWorkoutType("Бассейн");
        //        context.AddWorkoutType("Фитнес");
        //        context.AddWorkoutType("Силовая");
        //        context.AddWorkoutType("Кардио");
        //        context.AddWorkoutType("Йога");

        //        context.AddTrainer("Иванова", "Анна", "Петровна", new DateTime(1990, 10, 18), 100001, 1001, 10, "Мастер спорта по плаванию", "89991234567", "Tivanova90", "IvanovaA");
        //        context.AddTrainer("Смирнов", "Алексей", "Игоревич", new DateTime(1982, 7, 11), 100002, 1002, 15, "Мастер спорта по боксу", "89876543210", "Tsmirnov86", "SmirnovA");
        //        context.AddTrainer("Петров", "Дмитрий", "Олегович", new DateTime(1995, 7, 11), 100003, 1003, 5, "Мастер спорта по гимнастике", "89255557777", "Tpetrov95", "PetrovD");
        //        context.AddTrainer("Казанцева", "Дарья", "Сергеевна", new DateTime(1993, 8, 24), 100004, 1004, 10, "Мастер спорта по легкой атлетике", "89991234555", "Tkazantseva93", "KazantsevaD");
        //        context.AddTrainer("Козлов", "Федор", "Александрович", new DateTime(1997, 2, 28), 100005, 1005, 8, "Кандидат в мастера спорта по плаванию", "89997654321", "Tkozlov97", "KozlovF");

        //        context.AddWorkout(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0),
        //               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 0),
        //               "Среда", 2, 1, 1);
        //        context.AddWorkout(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0),
        //               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0),
        //               "Среда", 1, 2, 4);
        //        context.AddWorkout(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 0),
        //               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 30, 0),
        //               "Среда", 4, 3, 2);
        //        context.AddWorkout(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0),
        //                           new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 0),
        //                           "Четверг", 2, 1, 1);
        //context.AddWorkout(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0),
        //                           new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 30, 0),
        //                           "Четверг", 3, 5, 3);

        //        context.AddVisiting(new DateTime(2024, 4, 10), new DateTime(2024, 4, 10, 12, 30, 0), new DateTime(2024, 4, 10, 13, 40, 0), 1);
        //        context.AddVisiting(new DateTime(2024, 4, 10), new DateTime(2024, 4, 10, 15, 50, 0), new DateTime(2024, 4, 10, 17, 10, 0), 2);
        //        context.AddVisiting(new DateTime(2024, 4, 10), new DateTime(2024, 4, 10, 13, 30, 0), new DateTime(2024, 4, 10, 14, 40, 0), 3);
        //        context.AddVisiting(new DateTime(2024, 4, 11), new DateTime(2024, 4, 11, 12, 25, 0), new DateTime(2024, 4, 11, 13, 40, 0), 1);
        //        context.AddVisiting(new DateTime(2024, 4, 11), new DateTime(2024, 4, 11, 18, 30, 0), new DateTime(2024, 4, 11, 20, 00, 0), 4);

        //        context.AddSubscriptionType("Школьный");
        //        context.AddSubscriptionType("Годовой абонемент");
        //        context.AddSubscriptionType("Студенческий");
        //        context.AddSubscriptionType("Разовое занятие");
        //        context.AddSubscriptionType("Безлимит на 1 месяц");

        //        context.AddSubscription(1400, "1 месяц", 1);
        //        context.AddSubscription(18000, "Год", 2);
        //        context.AddSubscription(1700, "1 месяц", 3);
        //        context.AddSubscription(300, "Одно занятие", 4);
        //        context.AddSubscription(2000, "1 месяц", 5);

        //        context.AddPayment(new DateTime(2024, 04, 09), 18000, "Безналичные", 1);
        //        context.AddPayment(new DateTime(2024, 04, 02), 18000, "Безналичные", 2);
        //        context.AddPayment(new DateTime(2024, 04, 05), 300, "Наличные", 3);
        //        context.AddPayment(new DateTime(2024, 04, 08), 2000, "Наличные", 4);
        //        context.AddPayment(new DateTime(2024, 04, 08), 18000, "Безналичные", 5);

        //        context.AddPersonalSubscription(2, 1, 1);
        //        context.AddPersonalSubscription(2, 2, 2);
        //        context.AddPersonalSubscription(4, 3, 3);
        //        context.AddPersonalSubscription(5, 4, 4);
        //        context.AddPersonalSubscription(2, 5, 5);

        //        context.AddClientWorkout(1, 1);
        //        context.AddClientWorkout(2, 2);
        //        context.AddClientWorkout(3, 3);
        //        context.AddClientWorkout(1, 1);
        //        context.AddClientWorkout(4, 5);
        //    }
        //}
    }
}
