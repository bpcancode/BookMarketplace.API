using BookMarketplace.App.View;

namespace BookMarketplace.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SingupView), typeof(SingupView));
        }
    }
}
