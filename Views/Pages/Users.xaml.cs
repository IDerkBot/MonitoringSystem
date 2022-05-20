using System.Linq;
using System.Windows.Controls;
using SystemMonitoring.Models.Entity;

namespace SystemMonitoring.Views.Pages
{
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            DGUser.ItemsSource = dbMonitoringEntities.GetContext().Users.ToList();
        }
    }
}