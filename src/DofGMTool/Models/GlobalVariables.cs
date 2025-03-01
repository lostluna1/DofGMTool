

namespace DofGMTool.Models;
public class GlobalVariables
{
    private static readonly object _lock = new();

    private GlobalVariables() { }

    public static GlobalVariables Instance
    {
        get
        {
            if (field == null)
            {
                lock (_lock)
                {
                    field ??= new GlobalVariables();
                }
            }
            return field;
        }
    }

    public CharacInfo? GlobalCurrentCharacInfo { get; set; }

    public Accounts? Accounts { get; set; }
}
