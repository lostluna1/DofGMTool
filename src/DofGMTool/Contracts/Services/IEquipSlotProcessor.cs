using DofGMTool.Models;

namespace DofGMTool.Contracts.Services;
public interface IEquipSlotProcessor
{
    List<byte[]> ExtractEquipSlots(byte[] decompressedData);
    List<EquipSlotModel> ConvertSlotsToEquipSlotModels(List<byte[]> equipSlots);
    string ReverseGroups(string input);
    ulong ConvertToDecimal(string binaryString);
    List<byte[]> UpdateEquipSlotData(List<byte[]> equipSlots, int slotIndex, ulong newValue, int bitStartIndex, int bitLength);
    byte[] CompressBytes(byte[] sourceByte);
    byte[] CompressEquipSlots(List<byte[]> equipSlots);
}
