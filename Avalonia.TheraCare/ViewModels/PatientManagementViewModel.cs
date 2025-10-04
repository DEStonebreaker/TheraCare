using System.Collections.ObjectModel;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class PatientManagementViewModel : ViewModelBase
{
    
    [ObservableProperty] private ObservableCollection<string> _users;

    public PatientManagementViewModel()
    {
        Users = new ObservableCollection<string> {"Frank Ocean", "Bob Meyers", "Steven Irwin"};
    }

    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }
}