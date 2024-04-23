using System;
using Aaltoenergia.Model;
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
using System.Xml.Linq;

namespace Aaltoenergia.View.users
{
    public partial class EditClient : Window
    {
        private Client client;
        ContextDatabase db = new();
        public EditClient(Client selectedClient)
        {
            InitializeComponent();
            client = selectedClient;
            LoadClientData();
        }

        private void LoadClientData()
        {
            LName.Text = client.LName;
            FName.Text = client.FName;
            PName.Text = client.PName;
            BDate.Text = client.BDate.ToString();
            PassportSeries.Text = client.PassportSeries.ToString();
            PassportNumber.Text = client.PassportNumber.ToString();
            Phone.Text = client.Phone.ToString();
            Password.Text = client.Password;
            PersonalSubscriptionID.Text = client.PersonalSubscriptionID.ToString();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            client.LName = LName.Text.Trim();
            client.FName = FName.Text.Trim();
            client.PName = PName.Text.Trim();
            client.BDate = DateTime.Parse(BDate.Text.Trim());
            client.PassportSeries = int.Parse(PassportSeries.Text.Trim());
            client.PassportNumber = int.Parse(PassportNumber.Text.Trim());
            client.Phone = Phone.Text.Trim();
            client.Password = Password.Text.Trim();
            if (int.TryParse(PersonalSubscriptionID.Text.Trim(), out int personalSubscriptionID))
            {
                client.PersonalSubscriptionID = personalSubscriptionID;
            }
            else if (string.IsNullOrEmpty(PersonalSubscriptionID.Text.Trim()))
            {
                client.PersonalSubscriptionID = null;
            }

            db.client.Update(client);
            db.SaveChanges();

            MessageBox.Show("Данные клиента успешно обновлены :)");
            ClientWindow wClientWindow = new();
            wClientWindow.Show();
            Close();
        }

        private void BtCanсel_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow wClientWindow = new();
            wClientWindow.Show();
            Close();
        }
    }
}
