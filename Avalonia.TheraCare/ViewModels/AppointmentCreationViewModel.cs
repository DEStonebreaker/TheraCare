using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class AppointmentCreationViewModel : ViewModelBase
{
    [ObservableProperty] private string? _physicianSearch;
    [ObservableProperty] private string? _patientSearch;
    [ObservableProperty] private Physician? _selectedPhysician;
    [ObservableProperty] private Patient? _selectedPatient;
    [ObservableProperty] private string? _notes;
    [ObservableProperty] private DateTime? _date;
    [ObservableProperty] private TimeSpan? _apptSpan;
    [ObservableProperty] private Guid? _selectPatientId;
    
    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    public AppointmentCreationViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
        Physicians = PhysicianProxy.Current.GetPhysicians();
    }

    [RelayCommand]
    public void CreateAppointment()
    {
        DateTime? obj = Date + ApptSpan;
        var appt = AppointmentFactory.ApptFromArgs(SelectedPhysician, SelectedPatient, obj, true, Notes);
        AppointmentProxy.Current.Create(appt);
    }

    [RelayCommand]
    public void DisplayEm()
    {
        AppointmentProxy.Current.DisplayAll();
    }

    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentViewModel()));
    }
}