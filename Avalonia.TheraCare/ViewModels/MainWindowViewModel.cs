using System;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    // MainVM
    [ObservableProperty] private ViewModelBase _currentViewModel;
    // Services
    // ViewModels for Navigation
    private readonly HomeViewModel _homeViewModel = new ();
    
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

}