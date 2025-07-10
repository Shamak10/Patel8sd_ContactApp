using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Patel8sd_ContactApp.Services;
using Patel8sd_ContactApp.Views;
using System.Diagnostics; 
using Contact = Patel8sd_ContactApp.Models.Contact;

namespace Patel8sd_ContactApp.ViewModels
{
    public partial class ContactsViewModel : BaseViewModel
    {
        private readonly ContactService _contactService;
        public ObservableCollection<Contact> Contacts { get; }

        public ContactsViewModel(ContactService contactService)
        {
            Title = "Contacts";
            _contactService = contactService;
            Contacts = _contactService.GetContacts();
        }

        [RelayCommand]
        private async Task GoToDetailsAsync(Contact contact)
        {
            Debug.WriteLine("[ContactApp DEBUG] GoToDetailsAsync command executed.");
            if (contact == null)
            {
                Debug.WriteLine("[ContactApp DEBUG] Contact parameter is null.");
                return;
            }

            Debug.WriteLine($"[ContactApp DEBUG] Navigating to details for contact: {contact.Name}");
            await Shell.Current.GoToAsync(nameof(ContactDetailsPage), true, new Dictionary<string, object>
            {
                { "SelectedContact", contact }
            });
        }

        [RelayCommand]
        private async Task GoToAddContactAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(AddContactPage)}");
        }
    }
}
