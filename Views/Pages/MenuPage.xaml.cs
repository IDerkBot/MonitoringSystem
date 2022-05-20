using System.Windows;
using SystemMonitoring.Classes;
using SystemMonitoring.Pages;

namespace SystemMonitoring.Views.Pages
{
	public partial class MenuPage
	{
		public MenuPage() { InitializeComponent(); }
		private void BtnMoveField_Click(object sender, RoutedEventArgs e) => ManagerPage.Navigate(new FieldSelect());
		private void BtnMoveReports_Click(object sender, RoutedEventArgs e) => ManagerPage.Navigate(new Reports());
		private void BtnMoveCultures_Click(object sender, RoutedEventArgs e) => ManagerPage.Navigate(new CulturesPage());
		private void BtnMoveUsers_Click(object sender, RoutedEventArgs e) => ManagerPage.Navigate(new Users());
        private void BtnMoveFertilizers_OnClick(object sender, RoutedEventArgs e) => ManagerPage.Navigate(new Users());
	}
}