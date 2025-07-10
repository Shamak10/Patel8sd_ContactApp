using Patel8sd_ContactApp.ViewModels;

namespace Patel8sd_ContactApp.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage(ContactsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
