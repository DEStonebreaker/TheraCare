using System.Collections.ObjectModel;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
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
}