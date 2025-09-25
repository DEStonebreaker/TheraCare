using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Repositories;

public class PatientRepository : IRepository<Patient>
{
    private readonly List<Patient?> _patients = new List<Patient?>();

    // private static PatientProxy? _instance;
    private static readonly Lock InstanceLock = new Lock();

    public Patient Create(Patient patient)
    {
        lock (InstanceLock)
        {
            _patients.Add(patient);
            return patient;
        }
    }

    public Patient Update(Patient patient)
    {
        lock (InstanceLock)
        {
            int index = _patients.FindIndex(p => p?.Id == patient.Id);
            if (index != -1)
            {
                _patients[index] = patient;
                return patient;
            }
        }

        return patient;
    }

    public Patient GetById(Guid id)
    {
        lock (InstanceLock)
        {
            Patient? patient = _patients.FirstOrDefault(p => p?.Id == id);
            return patient;
        }
    }

    public IEnumerable<Patient?> GetAll()
    {
        lock (InstanceLock)
        {
            return _patients;
        }
    }

    public void Delete(Guid id)
    {
        lock (InstanceLock)
        {
            int index = _patients.FindIndex(p => p?.Id == id);
            if (index != -1)
            {
                _patients.RemoveAt(index);
            }
        }
    }

    public void Display()
    {
        lock (InstanceLock)
        {
            foreach (var patient in _patients)
            {
                Console.WriteLine($"{patient?.Id}: {patient?.LastName}, {patient?.FirstName}");
            }
        }
    }
}