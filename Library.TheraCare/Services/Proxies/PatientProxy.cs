using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Repositories;

namespace Library.TheraCare.Services.Proxies;

public class PatientProxy
{
    private static PatientProxy? _instance;
    private readonly PatientRepository _patientRepository;
    private static readonly Lock InstanceLock = new Lock();

    private PatientProxy(PatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public static PatientProxy Current
    {
        get
        {
            lock (InstanceLock)
            {
                _instance ??= new PatientProxy(new PatientRepository()); // if null, start proxy.
            }

            return _instance;
        }
    }

    public IEnumerable<Patient?> GetPatients => _patientRepository.GetAll();

    public Patient Create()
    {
        Patient patient = PatientFactory.FromCli();
        patient = _patientRepository.Create(patient);
        return patient;
    }

    public Patient GetPatient(Guid id)
    {
        Patient? patient = _patientRepository.GetById(id);
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient));
        }

        return patient;
    }

    public void DisplayPatients()
    {
        _patientRepository.Display();
    }

    public bool UpdatePatient(Guid patientId)
    {
        var patient = _patientRepository.GetById(patientId);
        Patient newPatient = PatientFactory.PatientUpdater(patient);
        _patientRepository.Update(newPatient);
        return true;
    }

    public void Delete(Guid id)
    {
        _patientRepository.Delete(id);
    }
}