using ChampManage.MAUI.Views;

namespace ChampManage.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NewsDetailsPage), typeof(NewsDetailsPage));
        }
    }
}