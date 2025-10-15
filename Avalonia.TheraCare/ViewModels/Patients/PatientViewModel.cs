using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class PatientViewModel : ViewModelBase
{
    
    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new HomeViewModel()));
    }

    [RelayCommand]
    public void GoToPatientCreation()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientCreationViewModel()));
    }

    [RelayCommand]
    public void GoToPatientManagement()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientManagementViewModel()));
    }
}