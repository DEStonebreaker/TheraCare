using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels.Appointments;

public partial class AppointmentViewModel : ViewModelBase
{
    
    // Buttons and Event Handling
    [RelayCommand]
    public void GoToCreation()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentCreationViewModel()));
    }
    
    [RelayCommand]
    public void GoToManagement()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentManagementViewModel()));
    }
    
    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new Home.HomeViewModel()));
    }
}