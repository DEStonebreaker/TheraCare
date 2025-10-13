using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class AppointmentCreationViewModel : ViewModelBase
{
    [ObservableProperty] private string? _physicianSearch;
    [ObservableProperty] private string? _patientSearch;
    [ObservableProperty] private Physician? _selectedPhysician;
    [ObservableProperty] private Patient? _selectedPatient;
    
    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    public AppointmentCreationViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
        Physicians = PhysicianProxy.Current.GetPhysicians();
    }

    [RelayCommand]
    public void DebugSelected()
    {
        Console.WriteLine(SelectedPhysician.Id);
        Console.WriteLine(SelectedPatient.Id);
    }

    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentViewModel()));
    }
}