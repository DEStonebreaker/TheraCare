using Avalonia.TheraCare.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.TheraCare.Messages;

public class ViewChangeMessage : ValueChangedMessage<ViewModelBase>
{
    /**
     * Sends a message to the main viewmodel with a corresponding view.
     */
    public ViewChangeMessage(ViewModelBase viewModel) : base(viewModel)
    {
        
    }
    
}