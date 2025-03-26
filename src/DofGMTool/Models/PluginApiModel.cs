using Newtonsoft.Json;

namespace DofGMTool.Models;
public class Item
{
    public int ItemId { get; set; }
    public int Count { get; set; }
}

public class Request
{
    public int UserId { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
}
public class CharacInvenResponse
{
    [JsonProperty("characInven")]
    public int CharacInven { get; set; }
}

public class PowerUpEquipResponse
{
    public int Level { get; set; }
}