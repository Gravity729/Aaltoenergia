using Aaltoenergia.Model;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aaltoenergia.View.users
{
    public partial class MyRecord : Window
    {
        public MyRecord()
        {
            InitializeComponent();
            LoadMyWorkouts();
        }
        private void LoadMyWorkouts()
        {
            using (var db = new ContextDatabase())
            {
                var myWorkouts = db.сlientWorkout
                    .Include(cw => cw.Workout)
                    .ThenInclude(w => w.WorkoutType)
                    .Include(cw => cw.Workout.Trainer)
                    .Where(cw => cw.ClientID == App.currentClient.ClientID)
                    .Select(cw => cw.Workout)
                    .ToList();

                lvMyWorkout.ItemsSource = myWorkouts;
            }
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            ProfileWindow wProfileWindow = new();
            wProfileWindow.Show();
            Close();
        }
    }
}
