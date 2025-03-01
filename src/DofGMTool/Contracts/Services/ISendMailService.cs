using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.Contracts.Services;
public interface ISendMailService
{
    void DeletePostal(int id);

    Task<ObservableCollection<Equipments>> GetEquipmentExAsync(int partsetIndex, string? partsetName = null);
    Task<ObservableCollection<EquipmentPartset>> GetEquipmentPartsetAsync(string query);
    Task<ObservableCollection<Equipments>> GetItemsList(MailType type, string? query = null);
    ObservableCollection<_Postal> GetPostals();
    Task<string> GetRoleNameById(int characNo);
    int SendMail(MailType type, MailModel mailModel, ObservableCollection<Equipments>? equipments = null);
}
