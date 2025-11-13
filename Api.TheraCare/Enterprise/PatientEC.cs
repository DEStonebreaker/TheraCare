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
}