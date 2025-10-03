using Avalonia.TheraCare.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.TheraCare.Messages;

public class ViewChangeMessage : ValueChangedMessage<ViewModelBase>
{
    /**
     * Sends a message to the main viewmodel with a corresponding view.
     * Note: This does not persist any page state between views. A new viewmodel
     * is constructed every time main vm receives the message.
     */
    public ViewChangeMessage(ViewModelBase viewModel) : base(viewModel)
    {
        
    }
    
}