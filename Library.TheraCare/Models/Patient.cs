namespace Library.TheraCare.Models;

public class Patient
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? BirthDate { get; set; }
    public string? Race { get; set; }
    public string? Gender { get; set; }

    public List<string> Diagnosis = new List<string>();
    public List<string> Medications = new List<string>();

    public void BuildPatient()
    {
        Console.Write("Enter the first name of the patient\n>> ");   
        this.FirstName = Console.ReadLine();                      
                                                                                     
        Console.Write("Enter the last name of the patient\n>> ");    
        this.LastName = Console.ReadLine();                       
                                                                                     
        Console.Write("Enter the address of the patient\n>> ");      
        this.Address = Console.ReadLine();                        
                                                                                     
        Console.Write("Enter the birth date of the patient\n>> ");   
        this.BirthDate = Console.ReadLine();                      
                                                                                     
        Console.Write("Enter the race of the patient\n>> ");         
        this.Race = Console.ReadLine();                           
                                                                                     
        Console.Write("Enter the gender of the patient (M|F)\n>> "); 
        this.Gender = Console.ReadLine();                         
    }
}