using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class PhysicianManagementViewModel : ViewModelBase
{
    // [ObservableProperty] private ObservableCollection<string> _users;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    [ObservableProperty] private Physician? _selectedPhysician;


    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }

    public PhysicianManagementViewModel()
    {
        Physicians = PhysicianProxy.Current.GetPhysicians();
    }

    [RelayCommand]
    public void EditPhysician()
    {
        if (SelectedPhysician == null) return;
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianCreationViewModel(SelectedPhysician)));
        NotifyPropertyChanged(nameof(Physicians));
    }

    [RelayCommand]
    public void DeletePhysician()
    {
        if (SelectedPhysician == null) return;

        PhysicianProxy.Current.DeletePhysician(SelectedPhysician.Id);
        Physicians.Remove(SelectedPhysician);
        SelectedPhysician = null;
    }
    
    public new event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}