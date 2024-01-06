using ClientApp.Views;

namespace ClientApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCustomerClicked(object sender, EventArgs e)
        {
            var customerPage = Handler.MauiContext.Services.GetService<CustomerPage>();
            Navigation.PushModalAsync(customerPage);
        }

        private void OnBookstoreClicked(object sender, EventArgs e)
        {
            var bookstorePage = Handler.MauiContext.Services.GetService<BookstorePage>();
            Navigation.PushModalAsync(bookstorePage);
        }
    }
}