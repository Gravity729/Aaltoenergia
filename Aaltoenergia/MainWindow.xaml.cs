using Aaltoenergia.View;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Authorization_OnClick(object sender, RoutedEventArgs e)
        {
            Authorization wAuthorization = new();
            wAuthorization.Show();
            this.Close();
        }
        private void Registration_OnClick(object sender, RoutedEventArgs e)
        {
            Registration wRegistration = new();
            wRegistration.Show();
            this.Close();
        }
    }
}