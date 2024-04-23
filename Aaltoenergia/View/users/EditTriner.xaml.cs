using Aaltoenergia.Model;
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
    public partial class EditTriner : Window
    {
        private Trainer trainer;
        ContextDatabase db = new();
        public EditTriner(Trainer selectedTrainer)
        {
            InitializeComponent();
            trainer = selectedTrainer;
            LoadTrainerData();
        }
        private void LoadTrainerData()
        {
            LName.Text = trainer.LName;
            FName.Text = trainer.FName;
            PName.Text = trainer.PName;
            BDate.Text = trainer.BDate.ToString();
            PassportSeries.Text = trainer.PassportSeries.ToString();
            PassportNumber.Text = trainer.PassportNumber.ToString();
            Experience.Text = trainer.Experience.ToString();
            Achievements.Text = trainer.Achievements;
            Phone.Text = trainer.Phone.ToString();
            Login.Text = trainer.Login;
            Password.Text = trainer.Password;

        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            trainer.LName = LName.Text.Trim();
            trainer.FName = FName.Text.Trim();
            trainer.PName = PName.Text.Trim();
            trainer.BDate = DateTime.Parse(BDate.Text.Trim());
            trainer.PassportSeries = int.Parse(PassportSeries.Text.Trim());
            trainer.PassportNumber = int.Parse(PassportNumber.Text.Trim());
            trainer.Experience = int.Parse(Experience.Text.Trim());
            trainer.Achievements = Achievements.Text.Trim();
            trainer.Phone = Phone.Text.Trim();
            trainer.Login = Login.Text.Trim();
            trainer.Password = Password.Text.Trim();

            db.trainer.Update(trainer);
            db.SaveChanges();

            MessageBox.Show("Данные тренера успешно обновлены :)");

            TrainerWindow wTrainerWindow = new();
            wTrainerWindow.Show();
            Close();
        }

        private void BtCanсel_Click(object sender, RoutedEventArgs e)
        {
            TrainerWindow wTrainerWindow = new();
            wTrainerWindow.Show();
            Close();
        }
    }
}
