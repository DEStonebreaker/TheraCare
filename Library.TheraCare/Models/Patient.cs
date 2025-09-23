using System.Collections.Immutable;

namespace Library.TheraCare.Models;

public class Patient
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Address { get; init; }  = string.Empty;
    public string BirthDate { get; init; } = string.Empty;
    public string Race { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;

    public List<string> Diagnosis { get; init; } = new List<string>();
    public List<string> Medications { get; init; } = new List<string>();
}