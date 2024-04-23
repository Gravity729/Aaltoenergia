using Aaltoenergia.Model;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Aaltoenergia.View.users
{
    public partial class ProfileWindow : Window
    {
        private ContextDatabase db = new ContextDatabase();
        public ProfileWindow()
        {
            InitializeComponent();

            if (App.UserRole == 1)
            {
                FIO.Content = "ФИО: " + App.currentClient.LName + " " + App.currentClient.FName + " " + App.currentClient.PName;
                bDate.Content = "Дата рождения: " + App.currentClient.BDate.ToShortDateString();
                phone.Content = "Номер телефона: " + App.currentClient.Phone;
                Clients.Visibility = Visibility.Collapsed;
            }
            else if (App.UserRole == 2)
            {
                FIO.Content = "ФИО: " + App.currentTrainer.LName + " " + App.currentTrainer.FName + " " + App.currentTrainer.PName;
                bDate.Content = "Дата рождения: " + App.currentTrainer.BDate.ToShortDateString();
                phone.Content = "Номер телефона: " + App.currentTrainer.Phone;
                achievements.Content = "Достижения: " + App.currentTrainer.Achievements;
                QrBox.Visibility = Visibility.Collapsed;
                Visits.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
                myWorkout.Visibility = Visibility.Collapsed;
            }
            else
            {
                FIO.Content = "ФИО: Морозова Мария Леонардовна";
                bDate.Content = "Дата рождения: 29.01.2005";
                phone.Content = "Номер телефона: 89157525293";
                QrBox.Visibility = Visibility.Collapsed;
                Visits.Visibility = Visibility.Collapsed;
                myWorkout.Visibility = Visibility.Collapsed;
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

        }
        public void ProfileWindow_OnLoaded(object sender, RoutedEventArgs e)
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

                    ImageQr.Source = bitmapImage;

                }
                ncardlk.Content = "Номер вашего абонемента: " + ps.PersonalSubscriptionID;
            }
            else
            {
                ncardlk.Content = "У вас пока нету абонемента, вы можете его купите :) ";
                ImageQr.Source = null;
            }
        }
        private void MyWorkout_OnClick(object sender, RoutedEventArgs e)
        {
            MyRecord wMyRecord = new();
            wMyRecord.Show();
            Close();
        }
    }
}
