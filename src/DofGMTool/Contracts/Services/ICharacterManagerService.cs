using DofGMTool.Models;

namespace DofGMTool.Contracts.Services;
public interface ICharacterManagerService
{
    void ChangeCurrentEquip(ulong newEquipId, int slotIndex);
    void PowerupCurrentEquip(ulong powerupLevel, int slotIndex);
}
