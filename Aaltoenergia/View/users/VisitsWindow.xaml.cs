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
    public partial class VisitsWindow : Window
    {
        public VisitsWindow()
        {
            InitializeComponent();

            if (App.UserRole == 1)
            {
                ContextDatabase db = new ContextDatabase();
                List<Visiting> visitings = db.visiting
                .Where(b => b.ClientID == App.currentClient.ClientID)
                .Select(b => new Visiting
                {
                    Date = b.Date.Date,
                    StartTime = b.StartTime,
                    EndTime = b.EndTime
                }).ToList();
                lvVisiting.ItemsSource = visitings;

                Clients.Visibility = Visibility.Collapsed;
            }
            else if (App.UserRole == 2)
            {
                lvVisiting.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
            }
            else
            {
                lvVisiting.Visibility = Visibility.Collapsed;
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
    }
}
