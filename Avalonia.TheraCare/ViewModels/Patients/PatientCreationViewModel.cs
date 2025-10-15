using System;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class PatientCreationViewModel : ViewModelBase
{
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
    private bool updateMode = false;

    public PatientCreationViewModel()
    {
    }

    public PatientCreationViewModel(Patient patient)
    {
        Id = patient.Id;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        Address = patient.Address;
        BirthDate  = patient.BirthDate;
        Race = patient.Race;
        Gender  = patient.Gender;
        Diagnosis = patient.Diagnosis;
        Medications = patient.Medications;
        updateMode = true;
        Title = "Patient Update";
    }
    
    [RelayCommand]
    public void Submit()
    {
        if (updateMode == false)
        {
            var pati = PatientFactory.FromArgs(FirstName, LastName, Address, BirthDate, Race, Gender, Diagnosis, Medications);
            PatientProxy.Current.CreatePatient(pati);
            ClearFields();
        }
        else
        {
            var pati = PatientFactory.FromArgsUpdater(Id, FirstName, LastName, Address, BirthDate, Race, Gender, Diagnosis, Medications);
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
    
    private void ClearFields()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Address = string.Empty;
        BirthDate = null;
        Race= string.Empty;
        Gender =  string.Empty;
        Diagnosis = string.Empty;
        Medications = string.Empty;
    }
}