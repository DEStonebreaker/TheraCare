using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.TheraCare.Messages;
using Avalonia.TheraCare.ViewModels.Dialogues;
using Avalonia.TheraCare.Views;
using Avalonia.TheraCare.Views.Dialogues;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Proxies;
using Newtonsoft.Json;

namespace Avalonia.TheraCare.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _currentViewModel;
    private readonly Home.HomeViewModel _homeViewModel = new();
    [ObservableProperty] private string tmpDir = string.Empty;
    [ObservableProperty] private string tmpFile = string.Empty;

    // Subscribes to Messages of ViewChange Type
    public MainWindowViewModel()
    {
        CurrentViewModel = _homeViewModel;
        WeakReferenceMessenger.Default.Register<ViewChangeMessage>
            (this, (r, e) => { CurrentViewModel = e.Value; });


        var configDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TheraCare"
        );
        if (!Directory.Exists(configDir))
            Directory.CreateDirectory(configDir);
        tmpFile = Path.Combine(configDir, "theracare_data.json");
        if (!File.Exists(tmpFile))
            File.Create(tmpFile);
    }

    [RelayCommand]
    public async Task Export()
    {
        var patients = await PatientProxy.Current.GetPatientsAsync();
        var patientString = JsonConvert.SerializeObject(
            patients.Where(b => b != null).Select(b => b));

        await using (StreamWriter sw = new StreamWriter($"{tmpFile}"))
        {
            await sw.WriteLineAsync(patientString);
        }
    }

    [RelayCommand]
    public async Task Import()
    {
        using (StreamReader sr = new StreamReader(tmpFile))
        {
            var patientString = await sr.ReadLineAsync();
            if (string.IsNullOrEmpty(patientString))
            {
                return;
            }

            var patients = JsonConvert.DeserializeObject<List<Patient>>(patientString);
            foreach (var pati in patients)
            {
                await PatientProxy.Current.CreatePatientAsync(pati);
            }
        }
    }
}