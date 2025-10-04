using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class PatientCreationViewModel : ViewModelBase
{
    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }
}