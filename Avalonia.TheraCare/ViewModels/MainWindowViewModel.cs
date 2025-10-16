using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.TheraCare.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _currentViewModel;
    private readonly Home.HomeViewModel _homeViewModel = new();

    // Subscribes to Messages of ViewChange Type
    public MainWindowViewModel()
    {
        CurrentViewModel = _homeViewModel;
        WeakReferenceMessenger.Default.Register<ViewChangeMessage>
            (this, (r, e) => { CurrentViewModel = e.Value; });
    }
}