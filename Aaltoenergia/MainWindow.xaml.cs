using Aaltoenergia.Model;
using Aaltoenergia.View;
using Aaltoenergia.View.users;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Aaltoenergia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Client authClient = null;
        Trainer authTrainer = null;
        private void Authorization_OnClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно";
                textBoxLogin.Background = Brushes.LightCoral;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не корректно";
                passBox.Background = Brushes.LightCoral;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                if (login == "*admin734" && pass == "qwerty")
                {
                    App.UserRole = 3;
                    MessageBox.Show("Добро пожаловать, Админ!");
                    HomeWindow wHomeWindow = new();
                    wHomeWindow.Show();
                    Close();
                }
                else if (char.IsDigit(login[0]))
                {

                    using (ContextDatabase context = new ContextDatabase())
                    {
                        authClient = context.client.Where(b => b.Phone == login && b.Password == pass).FirstOrDefault();
                    }
                    if (authClient != null)
                    {
                        App.UserRole = 1;
                        App.currentClient = authClient;
                        MessageBox.Show("Добро пожаловать, клиент!");
                        HomeWindow wHomeWindow = new();
                        wHomeWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введен неверно!");
                    }
                }
                else if (char.IsLetter(login[0]))
                {

                    using (ContextDatabase context = new ContextDatabase())
                    {
                        authTrainer = context.trainer.Where(t => t.Login == login && t.Password == pass).FirstOrDefault();
                    }
                    if (authTrainer != null)
                    {
                        App.UserRole = 2;
                        App.currentTrainer = authTrainer;
                        MessageBox.Show("Добро пожаловать, тренер!");
                        HomeWindow wHomeWindow = new();
                        wHomeWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введен неверно!");
                    }
                }

                else
                {
                    MessageBox.Show("Логин или пароль введен неверно!");
                }
            }
        }
    }
}