using Microsoft.Extensions.Logging;
using Patel8sd_ContactApp.Services;
using Patel8sd_ContactApp.ViewModels;
using Patel8sd_ContactApp.Views;

namespace Patel8sd_ContactApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register Services, ViewModels, and Views for Dependency Injection
        builder.Services.AddSingleton<ContactService>();

        builder.Services.AddSingleton<ContactsViewModel>();
        builder.Services.AddTransient<AddContactViewModel>();
        builder.Services.AddTransient<ContactDetailViewModel>();

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddTransient<AddContactPage>();
        builder.Services.AddTransient<ContactDetailsPage>();

        return builder.Build();
    }
}