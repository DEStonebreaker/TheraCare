using Library.TheraCare.Models;

namespace Library.TheraCare.Services.Factories;

public class PhysicianFactory
{
    public static Physician FromCli()
    {
        Console.Write("Enter the first name of the physician\n>> ");
        var firstName = Console.ReadLine();
        
        Console.Write("Enter the last name of the physician\n>> ");
        var lastName = Console.ReadLine()!;
        
        Console.Write("Enter the license number of the physician\n>> ");
        var licenseNumber = Console.ReadLine();
        
        Console.Write("Enter the graduation date of the physician\n>> ");
        var graduationDate = Console.ReadLine();
        
        Console.Write("Enter the specializations of the physician\n>> ");
        var specializations = Console.ReadLine();

        return new Physician
        {
            Id = Guid.NewGuid(),
            FirstName = Tools.StrNormalize(firstName),
            LastName = Tools.StrNormalize(lastName),
            LicenseNumber = Tools.StrNormalize(licenseNumber),
            GraduationDate = Tools.StrNormalize(graduationDate),
            Specializations = Tools.StrNormalize(specializations)
        };
    }

    public static Physician PhysicianUpdater(Physician existingPhysician)
    {
        Console.Write("Enter the first name of the physician\n>> ");
        var firstName = Console.ReadLine() ?? "";
        
        Console.Write("Enter the last name of the physician\n>> ");
        var lastName = Console.ReadLine() ?? "";
        
        Console.Write("Enter the license number of the physician\n>> ");
        var licenseNumber = Console.ReadLine() ?? "";
        
        Console.Write("Enter the graduation date of the physician\n>> ");
        var graduationDate = Console.ReadLine() ?? "";
        
        Console.Write("Enter the specializations of the physician\n>> ");
        var specializations = Console.ReadLine() ?? "";

        return new Physician
        {
            Id = Guid.NewGuid(),
            FirstName = (firstName == "" ? existingPhysician.FirstName : Tools.StrNormalize(firstName)),
            LastName = (firstName == "" ? existingPhysician.FirstName : Tools.StrNormalize(lastName)),
            LicenseNumber = (firstName == "" ? existingPhysician.FirstName : Tools.StrNormalize(licenseNumber)),
            GraduationDate = (firstName == "" ? existingPhysician.FirstName : Tools.StrNormalize(graduationDate)),
            Specializations = (firstName == "" ? existingPhysician.FirstName : Tools.StrNormalize(specializations))
        };
    }
}