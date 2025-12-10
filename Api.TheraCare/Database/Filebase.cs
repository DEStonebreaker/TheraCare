using Library.TheraCare.Models;
using Newtonsoft.Json;

namespace Api.TheraCare.Database
{
    public class Filebase
    {
        private string _root;
        private string _patientRoot;
        private static Filebase? _instance;
        
        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }
                return _instance;
            }
        }
        
        private Filebase()
        {
            _root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TheraCare"
            );
            _patientRoot = Path.Combine(_root, "Patients");
            
            // Ensure directories exist
            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }
            if (!Directory.Exists(_patientRoot))
            {
                Directory.CreateDirectory(_patientRoot);
            }
        }
        
        public Patient AddOrUpdate(Patient patient)
        {
            // Note: Patient already has a Guid Id, so we don't need to generate one
            // The Id is generated in the Patient class constructor
            
            // Go to the right place
            string path = Path.Combine(_patientRoot, $"{patient.Id}.json");
            
            // If the item has been previously persisted
            if (File.Exists(path))
            {
                // Delete the old version
                File.Delete(path);
            }
            
            // Write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(patient, Formatting.Indented));
            
            // Return the patient
            return patient;
        }
        
        public List<Patient> Patients
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var patients = new List<Patient>();
                
                foreach (var patientFile in root.GetFiles("*.json"))
                {
                    var patient = JsonConvert.DeserializeObject<Patient>(
                        File.ReadAllText(patientFile.FullName)
                    );
                    if (patient != null)
                    {
                        patients.Add(patient);
                    }
                }
                
                return patients;
            }
        }
        
        public bool Delete(Guid id)
        {
            string path = Path.Combine(_patientRoot, $"{id}.json");
            
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            
            return false;
        }
        
        public Patient? GetById(Guid id)
        {
            string path = Path.Combine(_patientRoot, $"{id}.json");
            
            if (File.Exists(path))
            {
                var patient = JsonConvert.DeserializeObject<Patient>(
                    File.ReadAllText(path)
                );
                return patient;
            }
            
            return null;
        }
    }
}