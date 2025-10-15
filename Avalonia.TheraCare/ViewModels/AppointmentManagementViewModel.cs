using System.Collections.ObjectModel;
using System.Reflection;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class AppointmentManagementViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<Appointment> _appointments;

    public AppointmentManagementViewModel()
    {
        Appointments = AppointmentProxy.Current.GetAppointments();
    }
    
    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new AppointmentViewModel()));
    }
}