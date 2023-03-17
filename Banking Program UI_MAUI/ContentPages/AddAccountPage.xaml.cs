namespace Banking_Program_UI_MAUI.ContentPages
{

	public partial class AddAccountPage : ContentPage
	{
		List<string> _accountTypes  = new List<string>{ "Savings", "Checking", "Certificate of Deposit" };

		public AddAccountPage()
		{
            InitializeComponent();
        }

		public List<string> AccountTypes => _accountTypes;
	}
}