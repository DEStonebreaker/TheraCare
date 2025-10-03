using System;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    // MainVM
    [ObservableProperty] private ViewModelBase _currentViewModel;
    
    // ViewModels for Navigation
    private readonly HomeViewModel _homeViewModel = new ();
    private readonly PatientViewModel _patientViewModel = new ();
    
    // Subscribe to Messages of ViewChange
    public MainWindowViewModel()
    {
        CurrentViewModel = _homeViewModel;
        WeakReferenceMessenger.Default.Register<ViewChangeMessage>
            (this, (r, e) =>
            {
                CurrentViewModel = e.Value;
            });
    }

    [RelayCommand]
    private void GoToPatient()
    {
        CurrentViewModel = new PatientViewModel();
    }
    
}