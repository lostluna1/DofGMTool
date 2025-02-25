namespace DofGMTool.Models;

using FreeSql.DataAnnotations;
using Windows.System;

public class EquipmentPartset
{
    public int Id { get; set; }
    public string? PartsetName { get; set; }
    public string? Path { get; set; }

    [Navigate(nameof(DofGMTool.Models.Equipments.PartsetIndex))]
    public List<Equipments>? Equipments { get; set; }
    //[Navigate(nameof(Equipments.EquipmentPartset))]
    //public List<Equipments> Equipments { get; set; } = new List<Equipments>();
}


