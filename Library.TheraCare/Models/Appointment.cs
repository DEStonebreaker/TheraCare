namespace Library.TheraCare.Models;

public class Appointment
{
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(30);
    public bool IsBooked { get; set; }

    public Physician? Physician { get; set; }

    // public Patient? Patient { get; set; }
    public string? Notes { get; set; }
}