using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DofGMTool.Messages;

public class ConnectionsUpdatedMessage : ValueChangedMessage<bool>
{
    public ConnectionsUpdatedMessage(bool value) : base(value)
    {
    }
}
