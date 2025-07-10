using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Contact = Patel8sd_ContactApp.Models.Contact; // Resolves ambiguity

namespace Patel8sd_ContactApp.ViewModels
{
    [QueryProperty(nameof(SelectedContact), "SelectedContact")]
    public partial class ContactDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Contact selectedContact;

        [ObservableProperty]
        private bool isEditing;

   
        private string editButtonText;
   
        public string EditButtonText
        {
            get => editButtonText;
            set => SetProperty(ref editButtonText, value);
        }

        public ContactDetailViewModel()
        {
            Title = "Contact Details";
            EditButtonText = "Edit";
        }

        [RelayCommand]
        private void ToggleEdit()
        {
            IsEditing = !IsEditing;
            EditButtonText = IsEditing ? "Cancel" : "Edit";
            Debug.WriteLine($"[ContactApp DEBUG] ToggleEdit executed. IsEditing: {IsEditing}");
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
