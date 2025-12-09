using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels.Physicians;

public partial class PhysicianManagementViewModel : ViewModelBase
{
    // Input Capture Properties
    [ObservableProperty] private Physician? _selectedPhysician;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    // CTORS. DEFAULT.

    public PhysicianManagementViewModel()
    {
        // Physicians = PhysicianProxy.Current.GetPhysicians();
        
        Physicians = new ObservableCollection<Physician>();
        _ = LoadPhysiciansAsync();
    }
    
    private async Task LoadPhysiciansAsync()
    {
        var physicians = await PhysicianProxy.Current.GetPhysiciansAsync();
        Physicians = new ObservableCollection<Physician>(physicians);
    }

    // Buttons and Event Handling

    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }


    [RelayCommand]
    public void EditPhysician()
    {
        if (SelectedPhysician == null) return;
        WeakReferenceMessenger.Default.Send(
            new ViewChangeMessage(new PhysicianCreationViewModel(SelectedPhysician)));
    }

    [RelayCommand]
    public async Task AsyncDeletePhysician()
    {
        if (SelectedPhysician == null) return;

        PhysicianProxy.Current.DeletePhysician(SelectedPhysician.Id);
        Physicians.Remove(SelectedPhysician);
        SelectedPhysician = null;
    }
}