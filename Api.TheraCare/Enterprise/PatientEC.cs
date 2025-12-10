using Api.TheraCare.Database;
using Library.TheraCare.Models;

namespace Api.TheraCare.Enterprise;

public class PatientEC
{
    public IEnumerable<Patient> GetPatients()
    {
        return Filebase.Current.Patients;
    }

    public Patient? GetById(Guid id)
    {
        return Filebase.Current.Patients.FirstOrDefault(p => p.Id == id);
    }

    public Patient? Delete(Guid id)
    {
        var toRemove = GetById(id);
        if (toRemove != null)
        {
            Filebase.Current.Delete(id);
        }

        return toRemove;
    }

    public Patient? Post(Patient patient)
    {
        var state = GetById(patient.Id);
        if (state != null) return null;
        
        return Filebase.Current.AddOrUpdate(patient);
        // return patient;
    }

    public bool Put(Guid id, Patient patient)
    {
        var pati = Filebase.Current.Patients.FirstOrDefault(p => p.Id == patient.Id);
        if (pati == null)
        {
            return false;
        }
        Filebase.Current.AddOrUpdate(patient);
        // int index = FakeDatabase.Patients.FindIndex(p => p.Id == patient.Id);
        // if (index != -1)
        // {
        //     FakeDatabase.Patients[index] = patient;
        //     return true;
        // }

        return true;
    }
}