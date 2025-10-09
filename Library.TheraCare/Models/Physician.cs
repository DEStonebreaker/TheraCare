namespace Library.TheraCare.Models;

public class Physician
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string LicenseNumber { get; init; } = string.Empty;
    public DateTime? GraduationDate { get; init; } = null;
    public string Specializations { get; init; } = string.Empty;

    // private List<List<Appointment>> _Appointments = new(); // Tools.BuildWeekSchedule();

    public override string ToString()
    {
        return $"Dr. {FirstName} {LastName} - {Specializations} (License: {LicenseNumber}) | Grad: {GraduationDate:MM.dd.yyyy}";
    }
}