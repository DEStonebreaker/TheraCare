namespace Library.TheraCare.Models;

public class Patient
{
    public Guid Id { get; init; } = Guid.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Address { get; init; }  = string.Empty;
    public DateTime? BirthDate { get; init; } = null;
    public string Race { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;
    public string Diagnosis { get; init; } = string.Empty;
    public string Medications { get; init; } = string.Empty;

    public override string ToString()
    {
        return $"{FirstName}, {LastName} | DOB: {BirthDate:MM.dd.yyyy}";
    }

    // public List<string> Diagnosis { get; init; } = new List<string>();
    // public List<string> Medications { get; init; } = new List<string>();
}