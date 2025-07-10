using Patel8sd_ContactApp.Views;

namespace Patel8sd_ContactApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register the route for the details page for navigation
        Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
    }
}