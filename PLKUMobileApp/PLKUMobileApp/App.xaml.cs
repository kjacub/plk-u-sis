using Microsoft.Extensions.DependencyInjection;

namespace PLKUMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();  
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}