using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;
using Microsoft.Extensions.DependencyInjection;

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
        Guid tmpId = SelectedPhysician.Id;
        int idx = Physicians.IndexOf(SelectedPhysician);
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianCreationViewModel(SelectedPhysician)));
        Physicians[idx] = PhysicianProxy.Current.GetPhysician(tmpId);
    }

    [RelayCommand]
    public void DeletePhysician()
    {
        if (SelectedPhysician == null) return;

        PhysicianProxy.Current.DeletePhysician(SelectedPhysician.Id);
        Physicians.Remove(SelectedPhysician);
        SelectedPhysician = null;
    }
}