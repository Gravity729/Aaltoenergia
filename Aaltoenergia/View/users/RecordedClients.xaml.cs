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
    public partial class RecordedСlients : Window
    {
        public List<Client> Clients { get; set; }
        public RecordedСlients(List<Client> clients)
        {
            InitializeComponent();
            Clients = clients;
            DataContext = this;
        }
        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            ScheduleWindow wScheduleWindow = new();
            wScheduleWindow.Show();
            Close();
        }
    }
}
