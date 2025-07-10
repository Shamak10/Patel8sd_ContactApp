using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Patel8sd_ContactApp.Services;
using Patel8sd_ContactApp.Views;
using Contact = Patel8sd_ContactApp.Models.Contact; 

namespace Patel8sd_ContactApp.ViewModels
{
    public partial class AddContactViewModel : BaseViewModel
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private string description;

        public AddContactViewModel(ContactService contactService)
        {
            Title = "Add New Contact";
            _contactService = contactService;
        }

        [RelayCommand]
        private async Task SaveContactAsync()
        {
            if (IsBusy) return;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                await Shell.Current.DisplayAlert("Error", "Name and Email are required.", "OK");
                return;
            }

            IsBusy = true;
            try
            {
                var newContact = new Contact
                {
                    Name = this.Name,
                    Email = this.Email,
                    PhoneNumber = this.PhoneNumber,
                    Description = this.Description
                };

                _contactService.AddContact(newContact);

                Name = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                Description = string.Empty;

                await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to save contact: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
