using Api.TheraCare.Database;
using Library.TheraCare.Models;

namespace Api.TheraCare.Enterprise;

public class PatientEC
{
    public IEnumerable<Patient> GetBlogs()
    {
        return FakeDatabase.Patients;
    }

    public Patient? GetById(Guid id)
    {
        return FakeDatabase.Patients.FirstOrDefault(p => p.Id == id);
    }

    public Patient? Delete(Guid id)
    {
        var toRemove = GetById(id);
        if (toRemove != null)
        {
            FakeDatabase.Patients.Remove(toRemove);
        }

        return toRemove;
    }

    public Patient? Post(Patient patient)
    {
        var state = GetById(patient.Id);
        if (state != null) return null;
        
        FakeDatabase.Patients.Add(patient);
        return patient;
    }

    public bool Put(Guid id, Patient patient)
    {
        var pati = FakeDatabase.Patients.FirstOrDefault(p => p.Id == patient.Id);
        if (pati == null)
        {
            return false;
        }

        int index = FakeDatabase.Patients.FindIndex(p => p.Id == patient.Id);
        if (index != -1)
        {
            FakeDatabase.Patients[index] = patient;
            return true;
        }

        return false;
    }
}