﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Aaltoenergia.View;


namespace Aaltoenergia.View.users
{
    public partial class TrainerWindow : Window
    {
        ContextDatabase db = new ContextDatabase();
        List<Trainer> trainers;
        public TrainerWindow()
        {
            InitializeComponent();

            UpdateTrainersList();

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
        private void Profile_OnClick(object sender, RoutedEventArgs e)
        {
            ProfileWindow wProfileWindow = new();
            wProfileWindow.Show();
            Close();
        }
        private void Clients_OnClick(object sender, RoutedEventArgs e)
        {
            ClientWindow wClientWindow = new();
            wClientWindow.Show();
            Close();
        }
        private void addTrainer_OnClick(object sender, RoutedEventArgs e)
        {
            NewTrainer wNewTrainer = new NewTrainer();
            wNewTrainer.Show();
            Close();
        }
        private void editTrainer_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvTrainer.SelectedItem != null)
            {
                Trainer selectedTrainer = lvTrainer.SelectedItem as Trainer;
                EditTriner wEditTrainer = new EditTriner(selectedTrainer);
                wEditTrainer.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования");
            }
        }
        private void deleteTrainer_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvTrainer.SelectedItem != null)
            {
                Trainer deleteTrainer = (Trainer)lvTrainer.SelectedItem;
                var fullName = deleteTrainer.LName + " " + deleteTrainer.FName + " " + deleteTrainer.PName;
                MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить клиента {fullName}?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    db.Entry(deleteTrainer).Reload();
                    db.trainer.Remove(deleteTrainer);
                    db.SaveChanges();
                    trainers = db.trainer.ToList();
                    lvTrainer.ItemsSource = trainers;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления");
            }
        }
        public void UpdateTrainersList()
        {
            trainers = db.trainer.ToList();
            lvTrainer.ItemsSource = trainers;
        }
    }
}
