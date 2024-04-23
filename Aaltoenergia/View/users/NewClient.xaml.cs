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
    public partial class NewClient : Window
    {
        ContextDatabase db;
        public NewClient()
        {
            InitializeComponent();
            db = new ContextDatabase();
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow wTrainer = new();
            wTrainer.Show();
            Close();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            string lName = LName.Text.Trim();
            string fName = FName.Text.Trim();
            string pName = PName.Text.Trim();
            string phone = Phone.Text.Trim();
            string password = Password.Text.Trim();

            if (DateTime.TryParse(BDate.Text.Trim(), out DateTime bDate) && int.TryParse(PassportNumber.Text.Trim(), out int passportNumber) &&
                 int.TryParse(PassportSeries.Text.Trim(), out int passportSeries) && (int.TryParse(PersonalSubscriptionID.Text.Trim(), out int personalSubscriptionID) ||
                 string.IsNullOrEmpty(PersonalSubscriptionID.Text.Trim())))
            {
                Client client = new Client(lName, fName, pName, bDate, passportNumber, passportSeries, phone, password, personalSubscriptionID);
                db.client.Add(client);
                db.SaveChanges();
                MessageBox.Show("Запись добавлена успешно");

                ClientWindow wTrainer = new();
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
