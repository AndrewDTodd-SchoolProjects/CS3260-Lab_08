using Banking_Program_UI_MAUI.ContentPages;

namespace Banking_Program_UI_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddAccountPage), typeof(AddAccountPage));
            Routing.RegisterRoute(nameof(SearchAccountsPage), typeof(SearchAccountsPage));
            Routing.RegisterRoute(nameof(AccountInfoPage), typeof(AccountInfoPage));
        }
    }
}