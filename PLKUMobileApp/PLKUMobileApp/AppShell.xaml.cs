namespace PLKUMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(Directory), typeof(Directory));
            Routing.RegisterRoute(nameof(ChartsPage), typeof(ChartsPage));
        }
    }
}


