using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels.Patients;

public partial class PatientManagementViewModel : ViewModelBase
{
    // Input Capture Properties
    [ObservableProperty] private Patient? _selectedPatient;
    [ObservableProperty] private ObservableCollection<Patient> _patients;

    public PatientManagementViewModel()
    {
        Patients = PatientProxy.Current.GetPatients();
    }

    // Buttons and Event Handling

    [RelayCommand]
    public void EditPatient()
    {
        if (SelectedPatient == null) return;
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientCreationViewModel(SelectedPatient)));
    }

    [RelayCommand]
    public async Task AsyncDeletePatient()
    {
        await Task.Run(() =>
        {
            if (SelectedPatient == null) return;

            PatientProxy.Current.DeletePatient(SelectedPatient.Id);
            Patients.Remove(SelectedPatient);
            SelectedPatient = null;
        });
    }

    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PatientViewModel()));
    }
}