namespace DofGMTool.Models;
public class EquipmentData
{
    public List<EquipmentPartset> Partsets { get; set; } = new List<EquipmentPartset>();
    public List<Equipments> Equipments { get; set; } = new List<Equipments>();
}
