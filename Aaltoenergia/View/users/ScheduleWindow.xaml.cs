using Aaltoenergia.Model;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aaltoenergia.View.users
{
    public partial class ScheduleWindow : Window
    {
        ContextDatabase db = new ContextDatabase();
        List<Workout> workouts;
        public ScheduleWindow()
        {
            InitializeComponent();
            ContextDatabase db = new ContextDatabase();
            workouts = db.workout
            .Include(w => w.WorkoutType)
            .Include(w => w.Trainer)
            .ToList();
            lvWorkout.ItemsSource = workouts;

            if (App.UserRole == 1)
            {
                ButtonBox.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
            }
            else if (App.UserRole == 2)
            {
                ButtonBox.Visibility = Visibility.Collapsed;
                Visits.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
            }
            else
            {
                Visits.Visibility = Visibility.Collapsed;
            }
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.ListViewItem listViewItem)
            {
                Workout currentWorkout = null;
                using (ContextDatabase db = new ContextDatabase())
                {
                    var selectedItem = listViewItem.Content as dynamic;

                    decimal Workouts = Convert.ToDecimal(selectedItem.WorkoutID);

                    currentWorkout = db.workout.FirstOrDefault(b => b.WorkoutID == Workouts);

                    RecordWindow wRecordWindow = new(currentWorkout);
                    wRecordWindow.Show();
                    Close();
                }
            }
        }
        private void Home_OnClick(object sender, RoutedEventArgs e)
        {
            HomeWindow wHomeWindow = new();
            wHomeWindow.Show();
            Close();
        }
        private void Trainer_OnClick(object sender, RoutedEventArgs e)
        {
            TrainerWindow wTrainerWindow = new();
            wTrainerWindow.Show();
            Close();
        }
        private void Schedule_OnClick(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wScheduleWindow = new();
            wScheduleWindow.Show();
            Close();
        }
        private void Shop_OnClick(object sender, RoutedEventArgs e)
        {
            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            Close();
        }
        private void Visits_OnClick(object sender, RoutedEventArgs e)
        {
            VisitsWindow wVisitsWindow = new();
            wVisitsWindow.Show();
            Close();
        }
        private void Clients_OnClick(object sender, RoutedEventArgs e)
        {
            ClientWindow wClientWindow = new();
            wClientWindow.Show();
            Close();
        }

        private void Profile_OnClick(object sender, RoutedEventArgs e)
        {
            ProfileWindow wProfileWindow = new();
            wProfileWindow.Show();
            Close();
        }
        private void addWorkout_OnClick(object sender, RoutedEventArgs e)
        {
            NewSchedule newScheduleWindow = new();
            newScheduleWindow.Show();
            Close();
        }
        private void editWorkout_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvWorkout.SelectedItem is Workout selectedWorkout)
            {
                EditSchedule wEditSchedule = new EditSchedule(db, selectedWorkout);

                wEditSchedule.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Пожалуйста, выберите абонемент для редактирования");
            }
        }
        private void deleteWorkout_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvWorkout.SelectedItem != null)
            {
                Workout deleteWorkout = (Workout)lvWorkout.SelectedItem;
                var startTime = deleteWorkout.StartTime.ToString("HH:mm");
                var endTime = deleteWorkout.EndTime.ToString("HH:mm");
                var fullName = deleteWorkout.DayOfTheWeek + "  " + deleteWorkout.WorkoutType.Name + " с " + startTime + " до " + endTime;
                MessageBoxResult result = System.Windows.MessageBox.Show($"Вы уверены, что хотите удалить тренировку: {fullName.ToLower()}?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    db.Entry(deleteWorkout).Reload();
                    db.workout.Remove(deleteWorkout);
                    db.SaveChanges();

                    workouts = db.workout
                        .Include(w => w.WorkoutType)
                        .Include(w => w.Trainer)
                        .ToList();

                    lvWorkout.ItemsSource = workouts;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Пожалуйста, выберите тренировку для удаления");
            }
        }
    }
}
