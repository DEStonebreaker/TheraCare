using System.Collections.ObjectModel;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;

namespace Library.TheraCare.Services.Proxies;

public class PatientProxy
{
    private static PatientProxy? _instance;
    private static readonly object _lock = new object();
    private readonly List<Patient> _patients = new List<Patient>();

    private PatientProxy()
    {
    }

    public static PatientProxy Current
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new PatientProxy();
            }

            return _instance;
        }
    }

    public IEnumerable<Patient> Patients
    {
        get
        {
            lock (_lock)
            {
                return _patients.ToList(); // Return a copy to prevent external modification
            }
        }
    }

    public Patient CreatePatient(Patient patient)
    {
        lock (_lock)
        {
            // Patient patient = PatientFactory.FromCli();
            _patients.Add(patient);
            return patient;
        }
    }

    public Patient? GetPatient(Guid id)
    {
        lock (_lock)
        {
            return _patients.FirstOrDefault(p => p.Id == id);
        }
    }
    
    public ObservableCollection<Patient> GetPatients()
    {
        return new ObservableCollection<Patient>(_patients);
    }

    public bool UpdatePatient(Patient patient)
    {
        lock (_lock)
        {
            var pati = _patients.FirstOrDefault(p => p.Id == patient.Id);
            if (pati == null)
            {
                return false;
            }

            int index = _patients.FindIndex(p => p.Id == patient.Id);
            if (index != -1)
            {
                _patients[index] = patient;
                return true;
            }

            return false;   
        }
    }

    public bool DeletePatient(Guid id)
    {
        lock (_lock)
        {
            int index = _patients.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _patients.RemoveAt(index);
                return true;
            }

            return false;
        }
    }

    public void DisplayPatients()
    {
        lock (_lock)
        {
            foreach (var patient in _patients)
            {
                Console.WriteLine($"{patient.Id}: {patient.LastName}, {patient.FirstName}");
            }
        }
    }
}