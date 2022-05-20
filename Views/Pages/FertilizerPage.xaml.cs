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
using SystemMonitoring.Models.Entity;

namespace SystemMonitoring.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для FertilizerPage.xaml
    /// </summary>
    public partial class FertilizerPage : Page
    {
        public FertilizerPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void FertilizerPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            DgFertilizer.ItemsSource = dbMonitoringEntities.GetContext().Fertilizers.ToList();
        }
    }
}
