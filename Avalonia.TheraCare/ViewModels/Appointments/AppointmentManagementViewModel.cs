using System.Collections.ObjectModel;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels.Appointments;

public partial class AppointmentManagementViewModel : ViewModelBase
{
    // Collection to be used in DataGrid
    [ObservableProperty] private ObservableCollection<Appointment> _appointments;

    /**
     * Init the VM with the current state of Appointments in the proxy.
     */
    public AppointmentManagementViewModel()
    {
        Appointments = AppointmentProxy.Current.GetAppointments();
    }
    
    // Buttons and Event Handling
    /**
     * Bound to the (Go) Back Button
     */
    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentViewModel()));
    }
}