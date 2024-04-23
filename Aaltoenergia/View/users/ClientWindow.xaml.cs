using Aaltoenergia.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ClientWindow : Window
    {
        ContextDatabase db = new ContextDatabase();
        List<Client> clients;
        public ClientWindow()
        {
            InitializeComponent();
            UpdateClientsList();
            if (App.UserRole == 3)
            {
                Visits.Visibility = Visibility.Collapsed;
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

        private void Profile_OnClick(object sender, RoutedEventArgs e)
        {

            ProfileWindow wProfileWindow = new();
            wProfileWindow.Show();
            Close();
        }
        private void Clients_OnClick(object sender, RoutedEventArgs e)
        {
            ClientWindow wClientWindow = new();
            wClientWindow.Show();
            Close();
        }
        private void addClient_OnClick(object sender, RoutedEventArgs e)
        {
            NewClient wNewClient = new();
            wNewClient.Show();
            Close();
        }


        private void editClient_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvClient.SelectedItem != null)
            {
                Client selectedClient = lvClient.SelectedItem as Client;
                //Hide();
                EditClient wEditClient = new EditClient(selectedClient);
                wEditClient.Show();
                //UpdateClientsList();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования");
            }
        }
        public void UpdateClientsList()
        {
            clients = db.client.ToList();
            lvClient.ItemsSource = clients;
        }
        private void deleteClient_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvClient.SelectedItem != null)
            {
                Client deleteClient = (Client)lvClient.SelectedItem;
                var fullName = deleteClient.LName + " " + deleteClient.FName + " " + deleteClient.PName;
                MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить клиента {fullName}?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    db.Entry(deleteClient).Reload();
                    db.client.Remove(deleteClient);
                    db.SaveChanges();
                    clients = db.client.ToList();
                    lvClient.ItemsSource = clients;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления");
            }
        }
    }
}