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
    public partial class NewSubscription : Window
    {
        private ContextDatabase db = new ContextDatabase();
        public NewSubscription()
        {
            InitializeComponent();
            LoadSubscriptionTypes();
        }
        private void LoadSubscriptionTypes()
        {
            SubscriptionTypeName.ItemsSource = db.subscriptionType.ToList();
            SubscriptionTypeName.DisplayMemberPath = "Name";
            SubscriptionTypeName.SelectedValuePath = "SubscriptionTypeID";
        }
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (SubscriptionTypeName.SelectedItem != null &&
                int.TryParse(SubscriptionTypeName.SelectedValue.ToString(), out int subscriptionTypeId) &&
                decimal.TryParse(Cost.Text.Trim(), out decimal cost))
            {

                var newSubscription = new Subscription
                {
                    SubscriptionTypeID = subscriptionTypeId,
                    Cost = cost,
                    Duration = Duration.Text.Trim()
                };

                db.subscription.Add(newSubscription);
                db.SaveChanges();
                MessageBox.Show("Абонемент успешно добавлен!");
                ShopWindow wShopWindow = new();
                wShopWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные!");
            }
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            Close();
        }
    }
}