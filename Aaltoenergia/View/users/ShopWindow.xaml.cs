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
    public partial class ShopWindow : Window
    {
        ContextDatabase db = new ContextDatabase();
        List<Subscription> subscriptions;
        public ShopWindow()
        {
            InitializeComponent();

            subscriptions = db.subscription.Include(s => s.SubscriptionType).ToList();

            lvSubscription.ItemsSource = subscriptions;
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
            if (sender is ListViewItem listViewItem)
            {
                Subscription currentSubscription = null;
                using (ContextDatabase db = new ContextDatabase())
                {
                    var selectedItem = listViewItem.Content as dynamic;

                    decimal costSubscription = Convert.ToDecimal(selectedItem.Cost);

                    currentSubscription = db.subscription.FirstOrDefault(b => b.Cost == costSubscription);

                    PayWindow wPayWindow = new PayWindow(currentSubscription);
                    wPayWindow.Show();
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

        private void addSubscription_OnClick(object sender, RoutedEventArgs e)
        {
            NewSubscription newSubscriptionWindow = new();
            newSubscriptionWindow.Show();
            Close();
        }
        private void editSubscription_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvSubscription.SelectedItem is Subscription selectedSubscription)
            {
                EditSubscription wEditSubscription = new EditSubscription(db, selectedSubscription);

                wEditSubscription.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для редактирования");
            }
        }
        private void deleteSubscription_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvSubscription.SelectedItem != null)
            {
                Subscription deleteSubscription = (Subscription)lvSubscription.SelectedItem;
                var fullName = deleteSubscription.SubscriptionType.Name + " " + deleteSubscription.Cost + "₽ ";
                MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить абонемент: {fullName}?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    db.Entry(deleteSubscription).Reload();
                    db.subscription.Remove(deleteSubscription);
                    db.SaveChanges();
                    subscriptions = db.subscription.ToList();
                    lvSubscription.ItemsSource = subscriptions;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для удаления");
            }
        }

    }
}
