using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Factories;

public static class PatientFactory
{
    public static Patient FromCli()
    {
        Console.Write("Enter the first name of the patient\n>> ");
        var fnIn = Console.ReadLine();

        Console.Write("Enter the last name of the patient\n>> ");
        var lnIn = Console.ReadLine();

        Console.Write("Enter the address of the patient\n>> ");
        var addrIn = Console.ReadLine();

        Console.Write("Enter the birth date of the patient\n>> ");
        var bdIn = Console.ReadLine();

        Console.Write("Enter the race of the patient\n>> ");
        var raceIn = Console.ReadLine();

        Console.Write("Enter the gender of the patient (M|F)\n>> ");
        var genIn = Console.ReadLine();

        return new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = Tools.StrNormalize(fnIn),
            LastName = Tools.StrNormalize(lnIn),
            Address = Tools.StrNormalize(addrIn),
            BirthDate = Tools.StrNormalize(bdIn),
            Race = Tools.StrNormalize(raceIn),
            Gender = Tools.StrNormalize(genIn)
        };
    }

    public static Patient PatientUpdater(Patient existingPatient)
    {
        Console.Write("Enter the new first name of the patient, ENTER to skip\n>> ");
        var fnIn = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the new last name of the patient, ENTER to skip\n>> ");
        var lnIn = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the new address of the patient, ENTER to skip\n>> ");
        var addrIn = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the new birth date of the patient, ENTER to skip\n>> ");
        var bdIn = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the new race of the patient, ENTER to skip\n>> ");
        var raceIn = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the new gender of the patient (M|F), ENTER to skip\n>> ");
        var genIn = Console.ReadLine() ?? String.Empty;

        return new Patient
        {
            Id = existingPatient.Id,
            FirstName = (fnIn == "" ? existingPatient.FirstName : Tools.StrNormalize(fnIn)),
            LastName = (lnIn == "" ? existingPatient.LastName : Tools.StrNormalize(lnIn)),
            Address = (addrIn == "" ? existingPatient.Address : Tools.StrNormalize(addrIn)),
            BirthDate = (bdIn == "" ? existingPatient.BirthDate : Tools.StrNormalize(bdIn)),
            Race = (raceIn == "" ? existingPatient.Race : Tools.StrNormalize(raceIn)),
            Gender = (genIn == "" ? existingPatient.Gender : Tools.StrNormalize(genIn)),
        };
    }
}