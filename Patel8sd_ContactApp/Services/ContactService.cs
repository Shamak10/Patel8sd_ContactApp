using System.Collections.ObjectModel;
using Patel8sd_ContactApp.Models;
using Contact = Patel8sd_ContactApp.Models.Contact; // Resolves ambiguity

namespace Patel8sd_ContactApp.Services
{
    public class ContactService
    {
        private readonly ObservableCollection<Contact> _contacts = new();

        public ObservableCollection<Contact> GetContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            if (contact != null)
            {
                _contacts.Add(contact);
            }
        }
    }
}