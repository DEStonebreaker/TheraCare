using Library.TheraCare.Models;

namespace Library.TheraCare.Services;

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
            FirstName = Tools.StrNormalize(fnIn),
            LastName = Tools.StrNormalize(lnIn),
            Address = Tools.StrNormalize(addrIn),
            BirthDate = Tools.StrNormalize(bdIn),
            Race = Tools.StrNormalize(raceIn),
            Gender = Tools.StrNormalize(genIn)
        };
    }
}