using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SystemMonitoring.Classes;
using SystemMonitoring.Models;
using SystemMonitoring.Models.Entity;
using SystemMonitoring.Views.Pages;

namespace SystemMonitoring.Pages
{
	public partial class FieldSelect
	{
		public FieldSelect()
		{
			InitializeComponent();
			//CbDistrict.ItemsSource = ;
			CbDistrict.ItemsSource = dbMonitoringEntities.GetContext().Fields
				.GroupBy(x => x.District)
				.Select(x => x.Key).ToList();
		}
		private void DistrictSelectChanged(object sender, SelectionChangedEventArgs e)
		{
			SpFieldNumber.IsEnabled = true;
			var selectDistrict = (sender as ComboBox)?.SelectedItem.ToString();
			CbField.ItemsSource = dbMonitoringEntities.GetContext().Fields
				.Where(x => x.District.Contains(selectDistrict))
				.Select(x => x.Number).ToList();
		}
		private void FieldDistrictChanged(object sender, SelectionChangedEventArgs e) { BtnNext.IsEnabled = true; }

		// Нажатие на кнопку вперед
		private void Next_Click(object sender, RoutedEventArgs e)
		{
			var field = dbMonitoringEntities.GetContext().Fields
				.Single(x => x.District == CbDistrict.SelectedItem.ToString() && x.Number == CbField.SelectedItem.ToString());
			var seed = new Seed();
			if (dbMonitoringEntities.GetContext().Seeds.Where(x => x.IDField == field.ID).ToList().Any())
				seed = dbMonitoringEntities.GetContext().Seeds.Single(x => x.IDField == field.ID);
			else
			{
				seed.IDField = field.ID;
				dbMonitoringEntities.GetContext().Seeds.Add(seed);
				dbMonitoringEntities.GetContext().SaveChanges();
				seed = dbMonitoringEntities.GetContext().Seeds.Single(x => x.IDField == seed.IDField);
			}
			Data.SelectSeeding = seed;
			ManagerPage.FieldMonitoringPage = new FieldMonitoring();
			ManagerPage.Page.Navigate(ManagerPage.FieldMonitoringPage);
		}
		private void AddDistrict_Click(object sender, RoutedEventArgs e) { ManagerPage.Navigate(new PagesAdd.AddDistrict()); }
		private void AddField_Click(object sender, RoutedEventArgs e) { ManagerPage.Navigate(new AddField(CbDistrict.SelectedItem.ToString())); }
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(Data.DistrictName)) return;
			var districts = dbMonitoringEntities.GetContext().Fields
				.Select(x => x.District).ToList();
			districts.Add(Data.DistrictName);
			CbDistrict.ItemsSource = districts;
			CbDistrict.SelectedItem = Data.DistrictName;
			var fields = dbMonitoringEntities.GetContext().Fields
				.Where(x => x.District == Data.DistrictName).ToList();
			if (fields.Any())
				CbField.ItemsSource = fields.Select(x => x.Number);
		}
	}
}