using Aaltoenergia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aaltoenergia.View.users
{
    public partial class RecordWindow : Window
    {
        public RecordWindow(Workout currentWorkout)
        {
            InitializeComponent();
            DataContext = currentWorkout;
            using (var db = new ContextDatabase())
            {
                var startTime = currentWorkout.StartTime.ToString("HH:mm");
                var endTime = currentWorkout.EndTime.ToString("HH:mm");
                var schedule = db.workout.Include(b => b.Trainer).FirstOrDefault(b => b.WorkoutID == currentWorkout.WorkoutID);
                var schedule1 = db.workout.Include(b => b.WorkoutType).FirstOrDefault(b => b.WorkoutTypeID == currentWorkout.WorkoutTypeID);
                if (schedule != null)
                {
                    workoutName.Text = $"{schedule1.WorkoutType.Name}\n{schedule.Trainer.FullName}\n{startTime} - {endTime}";
                }
            }

            if (App.UserRole == 1)
            {
                RecordedСlient.Visibility = Visibility.Collapsed;
            }
            else
            {
                RecordoOn.Visibility = Visibility.Collapsed;
            }
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wScheduleWindow = new();
            wScheduleWindow.Show();
            Close();
        }
        private void Recorded_OnClick(object sender, RoutedEventArgs e)
        {
            Recorded((Workout)DataContext);
        }

        private void Recorded(Workout currentWorkout)
        {
            using (var db = new ContextDatabase())
            {
                var IdWorkout = db.workout.FirstOrDefault(b => b.WorkoutID == currentWorkout.WorkoutID);
                if (App.currentClient?.ClientID != null && IdWorkout.WorkoutID != null)
                {
                    ClientWorkout clientWorkout = new ClientWorkout(App.currentClient.ClientID, IdWorkout.WorkoutID);

                    db.сlientWorkout.Add(clientWorkout);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Вы записались на занятие!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при записи на занятие: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: ClientID или WorkoutID не найдены.");
                }
            }
        }

        private void RecordedClients_OnClick(object sender, RoutedEventArgs e)
        {
            using (var db = new ContextDatabase())
            {
                var currentWorkout = (Workout)DataContext;
                var clients = db.сlientWorkout
                    .Where(cw => cw.WorkoutID == currentWorkout.WorkoutID)
                    .Select(cw => cw.Client)
                    .ToList();

                RecordedСlients wRecordedClients = new RecordedСlients(clients);
                wRecordedClients.Show();
                Close();
            }
        }
    }
}
