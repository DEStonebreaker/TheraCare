using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.TheraCare.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _currentViewModel;
    
    private readonly PatientMenuViewModel _patientMenuViewModel = new PatientMenuViewModel();
    private readonly PhysicianMenuViewModel _physicianMenuViewModel = new ();
    private readonly HomeMenuViewModel _homeMenuViewModel = new ();
    
    public MainWindowViewModel()
    {
        CurrentViewModel = _homeMenuViewModel;
    }
    
    [RelayCommand]
    public void GoToPatient()
    {
        CurrentViewModel = _patientMenuViewModel;
    }

    [RelayCommand]
    private void GoToPhysician()
    {
        CurrentViewModel = _physicianMenuViewModel;
    }


}