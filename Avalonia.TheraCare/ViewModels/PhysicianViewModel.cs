using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class PhysicianViewModel : ViewModelBase
{
    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new HomeViewModel()));
    }
    
    [RelayCommand]
    public void GoToCreation()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianCreationViewModel()));
    }
    
    [RelayCommand]
    public void GoToPhysicianManagement()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianManagementViewModel()));
    }
}