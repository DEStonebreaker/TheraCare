using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

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

}