using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact = Patel8sd_ContactApp.Models.Contact;

namespace Patel8sd_ContactApp.ViewModels
{
    [QueryProperty(nameof(SelectedContact), "SelectedContact")]
    public partial class ContactDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Contact selectedContact;

        [ObservableProperty]
        private bool isEditing;

        [ObservableProperty]
        private string editButtonText = "Edit";

        public ContactDetailViewModel()
        {
            Title = "Contact Details";
        }

        [RelayCommand]
        private void ToggleEdit()
        {
            IsEditing = !IsEditing;
            EditButtonText = IsEditing ? "Cancel" : "Edit";
        }

        [RelayCommand]
        private async Task SaveChangesAsync()
        {
            if (SelectedContact == null) return;

            IsEditing = false;
            EditButtonText = "Edit";
            await Shell.Current.DisplayAlert("Success", "Contact updated successfully!", "OK");
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}