using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [RelayCommand]
    public void GoToPatient()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }
    
    [RelayCommand]
    public void GoToPhysician()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }    
    
    [RelayCommand]
    public void GoToAdmin()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AdminViewModel()));
    }
    

}