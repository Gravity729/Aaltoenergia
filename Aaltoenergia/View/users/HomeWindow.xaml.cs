using Aaltoenergia.Model;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using MessagingToolkit.QRCode.Codec;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec.Data;

namespace Aaltoenergia.View.users
{
    public partial class HomeWindow : Window
    {
        private ContextDatabase db = new ContextDatabase();

        public HomeWindow()
        {
            InitializeComponent();

            if (App.UserRole == 1)
            {
                labelWelcome.Content = "Привет, " + App.currentClient.FName + "!";
                Clients.Visibility = Visibility.Collapsed;

            }
            else if (App.UserRole == 2)
            {
                labelWelcome.Content = "Привет, " + App.currentTrainer.FName + "!";
                Visits.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
                QrBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                labelWelcome.Content = "Привет, Админ!";
                QrBox.Visibility = Visibility.Collapsed;
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

        public void HomeWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            QRSet();
        }

        public void QRSet()
        {
            PersonalSubscription ps = null;

            if (App.UserRole == 1)
            {
                ps = db.personalSubscription.Where(c => c.ClientID == App.currentClient.ClientID).FirstOrDefault();
            }

            if (ps != null)
            {
                string dataToEncode = $"#{ps.PersonalSubscriptionID}, {App.currentClient.LName} {App.currentClient.FName} {App.currentClient.PName}";

                QRCodeEncoder qrEncoder = new QRCodeEncoder();

                qrEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

                qrEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;

                qrEncoder.QRCodeVersion = 7;

                Bitmap qrCodeImage = qrEncoder.Encode(dataToEncode);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    qrCodeImage.Save(memoryStream, ImageFormat.Png);
                    memoryStream.Position = 0;

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();

                    ImageQR.Source = bitmapImage;

                }
                ncard.Content = "Номер вашего абонемента: " + ps.PersonalSubscriptionID;
            }
            else
            {
                ncard.Content = "У вас пока нету абонемента :) ";
                ImageQR.Source = null;
            }
        }
    }
}