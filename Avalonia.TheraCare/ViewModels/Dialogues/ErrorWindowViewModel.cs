using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.TheraCare.ViewModels.Dialogues;

public partial class ErrorWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _errorMsg;

    public ErrorWindowViewModel(string errorMsg)
    {
        _errorMsg = "Invalid time selection, patient double booking";
    }
}