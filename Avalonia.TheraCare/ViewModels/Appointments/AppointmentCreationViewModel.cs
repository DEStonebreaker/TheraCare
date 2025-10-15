using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    [ObservableProperty] private string? _title = "Appointment Creation";

    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;
    [ObservableProperty] private bool _isActive = true;
    [ObservableProperty] private DateTime? _startTime;

    public AppointmentCreationViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
        Physicians = PhysicianProxy.Current.GetPhysicians();
    }

    [RelayCommand]
    public void CreateAppointment()
    {
        StartTime = Date + ApptSpan;
        var appt = AppointmentFactory.ApptFromArgs(SelectedPhysician, SelectedPatient, StartTime, true, Notes);
        if (!(AppointmentProxy.Current.Create(appt)))
            Title = "Appointment Already Exists";
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

    partial void OnDateChanged(DateTime? value)
    {
        IsActive = IsValidTime();
    }

    partial void OnApptSpanChanged(TimeSpan? value)
    {
        IsActive = IsValidTime();
    }

    private bool IsValidTime()
    {
        StartTime = Date + ApptSpan;
        foreach (var apptTime in AppointmentProxy.Current.GetAppointments())
        {
            if ((apptTime.StartTime == StartTime)
                && ((apptTime.Physician == SelectedPhysician))
                || (apptTime.Patient == SelectedPatient))
            {
                return false;
            }
        }

        return true;
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}