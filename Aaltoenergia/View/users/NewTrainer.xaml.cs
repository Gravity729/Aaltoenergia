using Aaltoenergia.Model;
using Microsoft.VisualBasic.Logging;
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
    public partial class NewTrainer : Window
    {
        ContextDatabase db;
        public NewTrainer()
        {
            InitializeComponent();
            db = new ContextDatabase();
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            TrainerWindow wTrainer = new TrainerWindow();
            wTrainer.Show();
            Close();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            string lName = LName.Text.Trim();
            string fName = FName.Text.Trim();
            string pName = PName.Text.Trim();
            string achievements = Achievements.Text.Trim();
            string phone = Phone.Text.Trim();
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();
            DateTime bDate;
            int passportNumber;
            int passportSeries;
            int experience;
            if (DateTime.TryParse(BDate.Text.Trim(), out bDate) && int.TryParse(PassportNumber.Text.Trim(), out passportNumber)
                && int.TryParse(PassportSeries.Text.Trim(), out passportSeries) && int.TryParse(Experience.Text.Trim(), out experience))
            {
                Trainer trainer = new Trainer(lName, fName, pName, bDate, passportNumber, passportSeries, experience, achievements, phone, password, login);
                db.trainer.Add(trainer);
                db.SaveChanges();
                MessageBox.Show("Запись добавлена успешно");

                TrainerWindow wTrainer = new TrainerWindow();
                wTrainer.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные!");
            }
        }
    }
}
