namespace Banking_Program_UI_MAUI.ContentPages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        #region BUTTON_CLICKED_METHODS
        private async void ADD_ACCOUNTS_BUTTON_CLICKED(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddAccountPage));
        }

        private async void SEARCH_ACCOUNTS_BUTTON_CLICKED(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SearchAccountsPage));
        }

        private async void ACCOUNT_INFO_BUTTON_CLICKED(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AccountInfoPage));
        }
        #endregion
    }
}