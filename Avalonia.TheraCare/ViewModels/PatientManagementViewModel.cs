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

public partial class PatientManagementViewModel : ViewModelBase
{
    
    [ObservableProperty] private ObservableCollection<Patient> _patients;
    [ObservableProperty] private Patient? _selectedPatient;

    public PatientManagementViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
    }
    
    [RelayCommand]
    public void EditPatient()
    {
        if (SelectedPatient == null) return;
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientCreationViewModel(SelectedPatient)));
        NotifyPropertyChanged(nameof(Patients));
    }

    [RelayCommand]
    public void DeletePatient()
    {
        if (SelectedPatient == null) return;

        PatientProxy.Current.DeletePatient(SelectedPatient.Id);
        Patients.Remove(SelectedPatient);
        SelectedPatient = null;
    }
    
    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}