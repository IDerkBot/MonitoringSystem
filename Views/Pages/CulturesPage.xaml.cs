using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SystemMonitoring.Models.Entity;

namespace SystemMonitoring.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CulturesPage.xaml
    /// </summary>
    public partial class CulturesPage : Page
    {
        public CulturesPage()
        {
            InitializeComponent();
            DgCultures.ItemsSource = dbMonitoringEntities.GetContext().Cultures.ToList();
            CbCultures.ItemsSource = dbMonitoringEntities.GetContext().Cultures.Select(x => x.Name).Distinct().ToList();
        }
        void SelectCultureSeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DgCultures.ItemsSource = dbMonitoringEntities.GetContext().Cultures
                .Where(x => x.Name == CbCultures.SelectedItem.ToString()).ToList();

            var statuses = dbMonitoringEntities.GetContext().Cultures.Where(x => x.Name == CbCultures.SelectedItem.ToString()).Select(x => x.Status).Distinct().ToList();
            //System.Windows.Forms.MessageBox.Show($"{string.Join(", ", list)} - {list.Count()} ${list[0]}$ - {string.IsNullOrEmpty(list[0])}");
            if (statuses.Count > 1)
            {
                CbStatuses.IsEnabled = true;
                CbStatuses.ItemsSource = statuses;
            }
            else CbStatuses.IsEnabled = false;
        }
        void FilterCulture_Click(object sender, RoutedEventArgs e)
        {
            var selectSeed = CbCultures.SelectedItem.ToString();
            if (selectSeed != "")
            {
                if (CbStatuses.IsEnabled)
                {
                    var selectStatus = (CbStatuses.SelectedItem != null) ? CbStatuses.SelectedItem.ToString() : "";
                    if (selectStatus != "")
                    {
                        DgCultures.Items.Clear();
                        foreach (var item in dbMonitoringEntities.GetContext().Cultures.Where(x => x.Name == selectSeed && x.Status == selectStatus).ToList())
                        {
                            DgCultures.Items.Add(item);
                        }
                    }
                    else
                    {
                        DgCultures.Items.Clear();
                        foreach (var item in dbMonitoringEntities.GetContext().Cultures.Where(x => x.Name == selectSeed).ToList())
                        {
                            DgCultures.Items.Add(item);
                        }
                    }
                }
                else
                {
                    DgCultures.Items.Clear();
                    foreach (var item in dbMonitoringEntities.GetContext().Cultures.Where(x => x.Name == selectSeed).ToList())
                    {
                        DgCultures.Items.Add(item);
                    }
                }
            }
            else{
                System.Windows.Forms.MessageBox.Show($@"Вы не выбрали параметры фильтрации");
            }
        }
        void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
