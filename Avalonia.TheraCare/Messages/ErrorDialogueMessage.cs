using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.TheraCare.Messages;

/**
 * Used for message errors via a dialogue window.
 */
public class ErrorDialogueMessage : ValueChangedMessage<string>
{
    public ErrorDialogueMessage(string err) : base(err)
    {
        
    }
}