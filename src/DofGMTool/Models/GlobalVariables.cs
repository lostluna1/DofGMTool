

namespace DofGMTool.Models;
public class GlobalVariables
{
    private static GlobalVariables? _instance;
    private static readonly object _lock = new();

    private GlobalVariables() { }

    public static GlobalVariables Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new GlobalVariables();
                }
            }
            return _instance;
        }
    }

    public CharacInfo? GlobalCurrentCharacInfo { get; set; }
}
