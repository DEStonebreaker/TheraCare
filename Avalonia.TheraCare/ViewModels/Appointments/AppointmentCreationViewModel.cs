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
    [ObservableProperty] private Guid appointmentId;
    [ObservableProperty] private string? _physicianSearch;
    [ObservableProperty] private string? _patientSearch;
    [ObservableProperty] private Physician? _selectedPhysician;
    [ObservableProperty] private Patient? _selectedPatient;
    [ObservableProperty] private string? _notes;
    [ObservableProperty] private DateTime? _date;
    [ObservableProperty] private TimeSpan? _apptSpan;
    [ObservableProperty] private string? _title = "Appointment Creation";

    // Collections to be used in AutoCompleteBoxes
    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private ObservableCollection<Physician> _physicians;

    /**
     * Enables Submit, tracks date Validation for appointments
     */
    [ObservableProperty] private bool _isActive = false;

    [ObservableProperty] private bool _updateMode = false;
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

    public AppointmentCreationViewModel(Appointment appointment)
    {
        AppointmentId = appointment.Id;
        Patients = PatientProxy.Current.GetPatients();
        Physicians = PhysicianProxy.Current.GetPhysicians();
        SelectedPatient = appointment.Patient;
        SelectedPhysician = appointment.Physician;
        Notes = appointment.Notes;
        Date = appointment.StartTime.Value.Date;
        ApptSpan = appointment.StartTime.Value.TimeOfDay;
        UpdateMode = true;
    }

    // Buttons and Event Handling

    /**
     * Bound to Submit Button.
     */
    [RelayCommand]
    public void Submit()
    {
        StartTime = Date + ApptSpan;
        if (UpdateMode == false)
        {
            var appt = AppointmentFactory.ApptFromArgs(SelectedPhysician, SelectedPatient, StartTime, true, Notes);
            if (!(AppointmentProxy.Current.Create(appt)))
                Title = "Appointment Already Exists";
            ClearFields();
        }
        else
        {
            var appt = AppointmentFactory.ApptUpdateArgs(AppointmentId, SelectedPhysician, SelectedPatient, StartTime,
                true, Notes);
            if (!(AppointmentProxy.Current.Update(appt)))
                Title = "Appointment Already Exists";
            Title = "Appointment Successfully Updated";
            ClearFields();
        }
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
    partial void OnSelectedPhysicianChanged(Physician? value)
    {
        IsActive = IsValidTime();
    }

    partial void OnSelectedPatientChanged(Patient? value)
    {
        IsActive = IsValidTime();
    }


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

    // Helper functions
    private bool IsValidTime()
    {
        StartTime = Date + ApptSpan;
        if ((SelectedPatient == null) || (SelectedPhysician == null))
            return false;

        if (ApptSpan == null) return false;

        TimeSpan dayStart = new TimeSpan(9, 0, 0);
        TimeSpan dayEnd = new TimeSpan(17, 0, 0);
        if (ApptSpan < dayStart || ApptSpan > dayEnd)
        {
            return false;
        }

        if (Date.HasValue && (Date.Value.DayOfWeek == DayOfWeek.Saturday
                              || Date.Value.DayOfWeek == DayOfWeek.Sunday))
        {
            return false;
        }

        foreach (var apptTime in AppointmentProxy.Current.GetAppointments())
        {
            if (UpdateMode && (apptTime.Id == AppointmentId))
                continue;

            if (((apptTime.Physician == SelectedPhysician)
                 || (apptTime.Patient == SelectedPatient))
                && (apptTime.StartTime == StartTime))
            {
                return false;
            }
        }

        return true;
    }

    private void ClearFields()
    {
        // String.Empty on the Search properties leaves a character?
        IsActive = false;
        PhysicianSearch = "";
        SelectedPhysician = null;
        PatientSearch = "";
        SelectedPatient = null;
        Notes = String.Empty;
        Date = null;
        ApptSpan = null;
    }
}