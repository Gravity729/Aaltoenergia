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
    public partial class EditSchedule : Window
    {
        private ContextDatabase db = new ContextDatabase();
        private Workout currentWorkout;
        public EditSchedule(ContextDatabase context, Workout workoutToEdit)
        {
            InitializeComponent();
            db = context;
            currentWorkout = db.workout.Include(w => w.Trainer).FirstOrDefault(w => w.WorkoutID == workoutToEdit.WorkoutID);

            LoadWorkoutTypes();
            LoadTrainers();
            LoadSubscriptionData();
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
        private void LoadSubscriptionData()
        {
            DayOfTheWeek.Text = currentWorkout.DayOfTheWeek;
            TrainerFIO.SelectedValue = currentWorkout.TrainerID;
            WorkoutTypeName.SelectedValue = currentWorkout.WorkoutTypeID;
            StartTime.Text = currentWorkout.StartTime.ToString();
            EndTime.Text = currentWorkout.EndTime.ToString();
            LocationOfTheEvent.Text = currentWorkout.LocationOfTheEvent.ToString();
        }
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            currentWorkout.DayOfTheWeek = DayOfTheWeek.Text;
            currentWorkout.TrainerID = (int)TrainerFIO.SelectedValue;
            currentWorkout.WorkoutTypeID = (int)WorkoutTypeName.SelectedValue;
            currentWorkout.StartTime = DateTime.Parse(StartTime.Text);
            currentWorkout.EndTime = DateTime.Parse(EndTime.Text);
            currentWorkout.LocationOfTheEvent = int.Parse(LocationOfTheEvent.Text);

            db.SaveChanges();

            MessageBox.Show("Данные о тренировке успешно обновлены :3");

            ScheduleWindow wScheduleWindow = new ScheduleWindow();
            wScheduleWindow.Show();
            Close();
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wScheduleWindow = new ScheduleWindow();
            wScheduleWindow.Show();
            Close();
        }
    }
}
