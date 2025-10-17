using System.Collections.ObjectModel;
using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Proxies;

public class AppointmentProxy
{
    private static AppointmentProxy? _instance;
    private static readonly object _lock = new object();
    private readonly List<Appointment> _appointments = new List<Appointment>();

    public AppointmentProxy()
    {
    }

    public static AppointmentProxy Current
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new AppointmentProxy();
            }

            return _instance;
        }
    }

    public bool Create(Appointment appointment)
    {
        lock (_lock)
        {
            var test = _appointments.FirstOrDefault(appt => appt.StartTime == appointment.StartTime);
            if (test != null)
            {
                return false;
            }

            _appointments.Add(appointment);
            return true;
        }
    }

    public bool Update(Appointment appointment)
    {
        lock (_lock)
        {
            var existingAppt = _appointments.FirstOrDefault(x => x.Id == appointment.Id);
            if (existingAppt == null)
            {
                return false;
            }

            var conflictingAppt = _appointments.FirstOrDefault(appt =>
                appt.Id != appointment.Id && // Exclude the current appointment
                appt.StartTime == appointment.StartTime);

            if (conflictingAppt != null)
            {
                return false;
            }

            int idx = _appointments.FindIndex(x => x.Id == appointment.Id);
            if (idx != -1)
            {
                _appointments[idx] = appointment;
            }

            return true;
        }
    }

    public void Delete(Guid id)
    {
        lock (_lock)
        {
            int index = _appointments.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _appointments.RemoveAt(index);
            }
        }
    }

    public Appointment? GetById(Guid id)
    {
        lock (_lock)
        {
            return _appointments.FirstOrDefault(x => x.Id == id);
        }
    }

    public ObservableCollection<Appointment> GetAppointments()
    {
        lock (_lock)
        {
            return new ObservableCollection<Appointment>(_appointments);
        }
    }

    public void DisplayAll()
    {
        foreach (var appointment in _appointments)
        {
            Console.WriteLine(appointment);
        }
    }
}