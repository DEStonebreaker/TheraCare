using System;
using System.Collections.Generic;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;
using Library.TheraCare.Utilities;

namespace Avalonia.TheraCare.ViewModels.Patients;

public partial class PatientCreationViewModel : ViewModelBase
{
    // Input Capture Properties
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _address;
    [ObservableProperty] private DateTime? _birthDate;
    [ObservableProperty] private string _race;
    [ObservableProperty] private string _gender;
    [ObservableProperty] private string _medications;
    [ObservableProperty] private string _diagnosis;
    [ObservableProperty] private string _title = "Patient Creation";
    [ObservableProperty] private bool _submitable;

    public List<string> GenderOpts { get; } = new List<string>
    {
        "Male",
        "Female",
        "Other",
    };

    private bool updateMode = false;

    // CTORS
    /**
     * Default CTOR, Runs on Create Patient Menu
     */
    public PatientCreationViewModel()
    {
    }

    /**
     * Update CTOR, Runs when an edit command is called from the management
     * view model.
     */
    public PatientCreationViewModel(Patient patient)
    {
        Id = patient.Id;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        Address = patient.Address;
        BirthDate = patient.BirthDate;
        Race = patient.Race;
        Gender = patient.Gender;
        Diagnosis = patient.Diagnosis;
        Medications = patient.Medications;
        updateMode = true;
        Title = "Patient Update";
    }

    // Button and Event Handling
    
    /**
     * Handles both the patient creation function, and edit patient functionality.
     * If the edit button on the management view is pressed, update mode is true.
     */
    [RelayCommand]
    public void Submit()
    {
        if (updateMode == false)
        {
            var pati = PatientFactory.FromArgs(FirstName, LastName, Address, BirthDate, Race, Gender, Diagnosis,
                Medications);
            PatientProxy.Current.CreatePatient(pati);
            ClearFields();
        }
        else
        {
            var pati = PatientFactory.FromArgsUpdater(Id, FirstName, LastName, Address, BirthDate, Race, Gender,
                Diagnosis, Medications);
            PatientProxy.Current.UpdatePatient(pati);
            Title = "Successfully Updated Physician";
            ClearFields();
        }
    }

    [RelayCommand]
    public void GoBack()
    {
        if (updateMode == true)
        {
            updateMode = false;
            WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientManagementViewModel()));
            ClearFields();
            return;
        }

        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }

    partial void OnFirstNameChanged(string? value)
    {
        Submitable = CanSubmit();
    }
    
    partial void OnLastNameChanged(string? value)
    {
        Submitable = CanSubmit();
    }

    partial void OnBirthDateChanged(DateTime? value)
    {
        Submitable = CanSubmit();
    }

    // Helper Functions
    
    private bool CanSubmit()
    {
        if (FirstName == null || FirstName == "")
        {
            return false;
        }
        if (LastName == null || LastName == "")
        {
            return false;
        }

        if (BirthDate == null)
        {
            return false;
        }

        return true;
    }

    private void ClearFields()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Address = string.Empty;
        BirthDate = null;
        Race = string.Empty;
        Gender = string.Empty;
        Diagnosis = string.Empty;
        Medications = string.Empty;
    }
}