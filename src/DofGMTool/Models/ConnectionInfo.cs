using CommunityToolkit.Mvvm.ComponentModel;

namespace DofGMTool.Models;

public partial class ConnectionInfo : ObservableValidator
{
    [ObservableProperty]
    public partial string? Name { get; set; }
    [ObservableProperty]
    public partial string? Ip { get; set; }
    [ObservableProperty]
    public partial string? Port { get; set; }
    [ObservableProperty]
    public partial string? User { get; set; }
    [ObservableProperty]
    public partial string? Password { get; set; }
    [ObservableProperty]
    public partial bool IsSelected { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is ConnectionInfo other)
        {
            return Name == other.Name &&
                   Ip == other.Ip &&
                   Port == other.Port &&
                   User == other.User &&
                   Password == other.Password;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Ip, Port, User, Password);
    }
}


