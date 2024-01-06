namespace ClientApp.Views;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private void OnBackClicked(object sender, EventArgs e)
	{
        Navigation.PopModalAsync();
    }
}