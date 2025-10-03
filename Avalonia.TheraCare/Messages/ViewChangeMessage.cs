using Avalonia.TheraCare.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.TheraCare.Messages;

public class ViewChangeMessage : ValueChangedMessage<ViewModelBase>
{
    public ViewChangeMessage(ViewModelBase viewModel) : base(viewModel)
    {
        
    }
}