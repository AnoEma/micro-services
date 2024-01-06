namespace ClientApp.Views;

public partial class BookstorePage : ContentPage
{
	public BookstorePage()
	{
		InitializeComponent();
	}

    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}