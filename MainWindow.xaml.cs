using System;
using System.Windows;
using SystemMonitoring.Classes;
using SystemMonitoring.Models;
using SystemMonitoring.Pages;
using SystemMonitoring.Views.Pages;

namespace SystemMonitoring
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ManagerPage.Page = MainPage;
            ManagerPage.Navigate(new AuthPage());
        }

        private void MainPage_ContentRendered(object sender, EventArgs e)
        {
            if (ManagerPage.Page.Content.ToString().Contains("AuthPage") || ManagerPage.Page.Content.ToString().Contains("MenuPage"))
                Back.Visibility = Visibility.Hidden;
            else Back.Visibility = Visibility.Visible;
            if (ManagerPage.Page.Content.ToString().Contains("FieldMonitoring"))
                ManagerPage.FieldMonitoringPage.NavigateLoad();
        }
        private void ChangedSizeWindow(object sender, SizeChangedEventArgs e)
        {
            if(MainW.WindowState == WindowState.Maximized) 
                Data.SizeWindow = SystemParameters.PrimaryScreenWidth;
            else Data.SizeWindow = MainW.Width;
        }
        private void MainW_Closed(object sender, EventArgs e)
        {
            //if (ManagerPage.Page.Content.ToString().Contains("FieldMonitoring")) ManagerPage.FieldMonitoringPage.ClosePort();
            Close();
        }
    }
}