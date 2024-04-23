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
    public partial class EditSubscription : Window
    {
        private ContextDatabase db = new ContextDatabase();
        private Subscription currentSubscription;

        public EditSubscription(ContextDatabase context, Subscription subscriptionToEdit)
        {
            InitializeComponent();
            db = context;
            currentSubscription = subscriptionToEdit;
            LoadSubscriptionTypes();
            LoadSubscriptionData();
        }

        private void LoadSubscriptionTypes()
        {
            SubscriptionTypeName.ItemsSource = db.subscriptionType.ToList();
            SubscriptionTypeName.DisplayMemberPath = "Name";
            SubscriptionTypeName.SelectedValuePath = "SubscriptionTypeID";
        }

        private void LoadSubscriptionData()
        {
            SubscriptionTypeName.SelectedValue = currentSubscription.SubscriptionTypeID;
            Cost.Text = currentSubscription.Cost.ToString();
            Duration.Text = currentSubscription.Duration;
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            currentSubscription.SubscriptionTypeID = (int)SubscriptionTypeName.SelectedValue;
            currentSubscription.Cost = decimal.Parse(Cost.Text);
            currentSubscription.Duration = Duration.Text;

            MessageBox.Show("Данные абонемента успешно обновлены :)");
            db.subscription.Update(currentSubscription);
            db.SaveChanges();

            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            Close();
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            Close();
        }
    }
}
