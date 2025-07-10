using Patel8sd_ContactApp.ViewModels;

namespace Patel8sd_ContactApp.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage(AddContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}