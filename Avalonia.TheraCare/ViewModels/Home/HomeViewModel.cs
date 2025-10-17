using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels.Home;

public partial class HomeViewModel : ViewModelBase
{
    // Buttons and Event Handling
    [RelayCommand]
    public void GoToPatient()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new Patients.PatientViewModel()));
    }
    
    [RelayCommand]
    public void GoToPhysician()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new Physicians.PhysicianViewModel()));
    }    
    
    [RelayCommand]
    public void GoToAdmin()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new Appointments.AppointmentViewModel()));
    }
    

}