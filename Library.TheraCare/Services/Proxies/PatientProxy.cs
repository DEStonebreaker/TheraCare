using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;

namespace Library.TheraCare.Services.Proxies;

public class PatientProxy
{
    private readonly List<Patient?> _patients;

    private PatientProxy()
    {
        _patients = new List<Patient?>();
    }

    private static PatientProxy? _instance;
    private static readonly Lock InstanceLock = new Lock();

    public static PatientProxy Current
    {
        get
        {
            lock (InstanceLock)
            {
                _instance ??= new PatientProxy(); // if null, start proxy.
            }

            return _instance;
        }
    }

    public List<Patient?> Patients => _patients;

    public Patient AddPatient()
    {
        Patient patient = PatientFactory.FromCli();
        lock (InstanceLock)
        {
            _patients.Add(patient);
        }

        return patient;
    }

    public Patient GetPatient(Guid id)
    {
        Patient? patient = null;
        lock (InstanceLock)
        {
            patient = _patients.FirstOrDefault(p => p?.Id == id);
        }
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient));
        } 
        return patient;
    }

    public bool UpdatePatient(Patient patient)
    {
        lock (InstanceLock)
        {
            var result = _patients.FirstOrDefault(p => p?.Id == patient.Id);
            if (result != null)
            {
                throw new ArgumentNullException(nameof(patient));
                // or return false??
            }
        }
        return true;
    }

}