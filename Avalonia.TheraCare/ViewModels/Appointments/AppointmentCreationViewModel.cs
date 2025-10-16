using System;
using System.Collections.ObjectModel;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels.Appointments;

public partial class AppointmentCreationViewModel : ViewModelBase
{
    // Input Capture Properties
    [ObservableProperty] private string? _physicianSearch;
    [ObservableProperty] private string? _patientSearch;
    [ObservableProperty] private Physician? _selectedPhysician;
    [ObservableProperty] private Patient? _selectedPatient;
    [ObservableProperty] private string? _notes;
    [ObservableProperty] private DateTime? _date;
    [ObservableProperty] private TimeSpan? _apptSpan;
    [ObservableProperty] private Guid? _selectPatientId;
    [ObservableProperty] private string? _title = "Appointment Creation";

    // Collections to be used in AutoCompleteBoxes
    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    /**
     * Enables Submit, tracks date Validation for appointments
     */
    [ObservableProperty] private bool _isActive = true;
    [ObservableProperty] private DateTime? _startTime;

    /**
     * Init the VM with the current state of Patients and Physicians
     * from their respective proxies.
     */
    public AppointmentCreationViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
        Physicians = PhysicianProxy.Current.GetPhysicians();
    }

    // Buttons and Event Handling

    /**
     * Bound to Submit Button.
     */
    [RelayCommand]
    public void CreateAppointment()
    {
        StartTime = Date + ApptSpan;
        var appt = AppointmentFactory.ApptFromArgs(SelectedPhysician, SelectedPatient, StartTime, true, Notes);
        if (!(AppointmentProxy.Current.Create(appt)))
            Title = "Appointment Already Exists";
    }

    /**
     * Bound to Debug Button.
     */
    [RelayCommand]
    public void DisplayEm()
    {
        AppointmentProxy.Current.DisplayAll();
    }

    // Bound to (Go) Back Button.
    [RelayCommand]
    public void GoToHome()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentViewModel()));
    }

    // Observable(s) Handling. Each just updates on changed state.
    partial void OnDateChanged(DateTime? value)
    {
        IsActive = IsValidTime();
    }

    partial void OnApptSpanChanged(TimeSpan? value)
    {
        IsActive = IsValidTime();
    }

    /**
     * Checks to see if the selected Date and Start time is valid given the selected
     * patient and physician.
     */
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
}