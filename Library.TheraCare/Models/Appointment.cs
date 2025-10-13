namespace Library.TheraCare.Models;

public class Appointment
{
    /**
     * Setup so that a physician holds a list of appointments
     */
    public Guid Id { get; init; } = Guid.Empty;
    public DateTime? StartTime { get; init; } = null;
    public TimeSpan? Duration { get; init; } = TimeSpan.FromMinutes(30);
    public bool IsBooked { get; init; } = false;

    public Physician? Physician { get; init; } = null;
    public Patient? Patient { get; init; } = null;

    public string? Notes { get; set; }
}