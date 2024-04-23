using Aaltoenergia.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class PayWindow : Window
    {
        public PayWindow(Subscription currentSubscription)
        {
            InitializeComponent();

            DataContext = currentSubscription;

            using (var db = new ContextDatabase())
            {
                var subscription = db.subscription.Include(b => b.SubscriptionType).FirstOrDefault(b => b.SubscriptionTypeID == currentSubscription.SubscriptionTypeID);
                if (subscription != null)
                {
                    paySubscription.Text = $"{subscription.SubscriptionType.Name}\n{currentSubscription.Cost}₽\n{currentSubscription.Duration}";
                }
            }
            if (App.UserRole == 2)
            {
                Pay.Visibility = Visibility.Collapsed;
            }
            else if (App.UserRole == 3)
            {
                Pay.Visibility = Visibility.Collapsed;
            }
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            this.Close();
        }

        private void textBoxNcard_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxNcard.TextChanged -= textBoxNcard_TextChanged;

            string cleanedText = Regex.Replace(textBoxNcard.Text, "[^0-9 ]+", "").Replace(" ", "");
            StringBuilder formattedText = new StringBuilder();
            int counter = 0;
            int groupCounter = 0;
            foreach (char c in cleanedText)
            {
                if (groupCounter < 4)
                {
                    formattedText.Append(c);
                    groupCounter++;
                    counter++;
                }

                if (groupCounter == 4 && counter < 16)
                {
                    formattedText.Append(" ");
                    groupCounter = 0;
                }
            }

            textBoxNcard.Text = formattedText.ToString();

            if (textBoxNcard.Text.Length >= 19)
            {
                textBoxNcard.Text = textBoxNcard.Text.Substring(0, 19);
            }

            textBoxNcard.SelectionStart = textBoxNcard.Text.Length;

            textBoxNcard.TextChanged += textBoxNcard_TextChanged;
        }

        private void textBoxDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxDate.Text = Regex.Replace(textBoxDate.Text, "[^0-9]+", "/");

            if (textBoxDate.Text.Length == 2 && !textBoxDate.Text.Contains("/"))
            {
                textBoxDate.Text += "/";
                textBoxDate.CaretIndex = 3;
            }

            if (textBoxDate.Text.Length > 5)
            {
                textBoxDate.Text = textBoxDate.Text.Substring(0, 5);
            }
        }

        private void textBoxCvc_TextChanged(object sender, TextChangedEventArgs e)
        {

            textBoxCvc.Text = Regex.Replace(textBoxCvc.Text, "[^0-9]+", "");
            if (textBoxCvc.Text.Length > 3)
            {
                textBoxCvc.Text = textBoxCvc.Text.Substring(0, 3);
            }
        }

        private void Pay_OnClick(object sender, RoutedEventArgs e)
        {
            if (textBoxNcard.Text.Length == 19 &&
                textBoxDate.Text.Length == 5 &&
                textBoxCvc.Text.Length == 3)
            {

                MessageBox.Show("Оплата прошла успешно!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных.");
            }
        }
        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            ShopWindow wShopWindow = new();
            wShopWindow.Show();
            this.Close();
        }
    }
}
