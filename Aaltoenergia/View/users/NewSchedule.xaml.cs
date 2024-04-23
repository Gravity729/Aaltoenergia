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
using Aaltoenergia.Model;

namespace Aaltoenergia.View.users
{
    public partial class NewSchedule : Window
    {
        private ContextDatabase db = new ContextDatabase();
        public NewSchedule()
        {
            InitializeComponent();
            LoadWorkoutTypes();
            LoadTrainers();
        }
        private void LoadWorkoutTypes()
        {
            WorkoutTypeName.ItemsSource = db.workoutType.ToList();
            WorkoutTypeName.DisplayMemberPath = "Name";
            WorkoutTypeName.SelectedValuePath = "WorkoutTypeID";
        }
        private void LoadTrainers()
        {
            TrainerFIO.ItemsSource = db.trainer.ToList();
            TrainerFIO.DisplayMemberPath = "FullName";
            TrainerFIO.SelectedValuePath = "TrainerID";
        }
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(StartTime.Text.Trim(), out DateTime startTime) &&
                DateTime.TryParse(EndTime.Text.Trim(), out DateTime endTime) &&
                int.TryParse(LocationOfTheEvent.Text.Trim(), out int location) &&
                WorkoutTypeName.SelectedItem != null &&
                int.TryParse(WorkoutTypeName.SelectedValue.ToString(), out int workoutTypeId) &&
                TrainerFIO.SelectedItem != null &&
                int.TryParse(TrainerFIO.SelectedValue.ToString(), out int trainerId))
            {
                Workout newSchedule = new Workout(startTime, endTime, DayOfTheWeek.Text.Trim(), location, workoutTypeId, trainerId);
                db.workout.Add(newSchedule);
                db.SaveChanges();

                MessageBox.Show("Тренировка успешно добавлена");

                ScheduleWindow wScheduleWindow = new ScheduleWindow();
                wScheduleWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные!");
            }
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wScheduleWindow = new();
            wScheduleWindow.Show();
            Close();
        }
    }
}
