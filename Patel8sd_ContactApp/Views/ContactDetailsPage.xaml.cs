using Patel8sd_ContactApp.ViewModels;

namespace Patel8sd_ContactApp.Views;

public partial class ContactDetailsPage : ContentPage
{
    public ContactDetailsPage(ContactDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
