using System.Collections.ObjectModel;
using System.Text;
using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using pvfLoaderXinyu;

namespace DofGMTool.Services;
public class PvfExtensionsService : IPvfExtensionsService
{
    public void AnalysisDungeons(PvfFile pvf) => throw new NotImplementedException();

    public async Task<ObservableCollection<Equipments>> GetEquipments(PvfFile pvf)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var _pvfEncoding = Encoding.GetEncoding("gb2312");
        var itemDic = pvf.GetPvfFileByPath("equipment/equipment.lst", Encoding.UTF8);
        if (itemDic == null)
        {
            return new ObservableCollection<Equipments>();
        }

        var itemArr = itemDic.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();
        var total = itemArr.Count;

        var list = new ObservableCollection<Equipments>();
        for (var i = 0; i < total; i++)
        {
            var item = itemArr[i];
            var arr = item.Split("\t", StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 1)
            {
                continue;
            }

            var id = arr[0];
            var path = arr[1].Replace("`", "");
            var equipEdu = pvf.GetPvfFileByPath($"equipment/{path}", Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(equipEdu))
            {
                continue;
            }

            var eduInfos = equipEdu.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith("#")).ToList();
            if (eduInfos.Count <= 0)
            {
                continue;
            }

            var index = eduInfos.IndexOf("[name]");
            var name = eduInfos[index + 1].Replace("`", "");
            name = name.Replace($"<3::name_{id}", "");
            name = name.Replace(">", "");
            name = Encoding.GetEncoding("gb2312").GetString(_pvfEncoding.GetBytes(name));
            var iconMark = GetPvfPart(eduInfos, "[icon]");
            if (iconMark.Count <= 0)
            {
                iconMark = GetPvfPart(eduInfos, "[icon mark]");
            }

            var npkPath = string.Empty;
            var no = 0u;
            if (iconMark.Count > 0)
            {
                npkPath = iconMark[0].Replace("`", "");
                if (iconMark[1].Contains("`"))
                {
                    no = uint.Parse(iconMark[2]);
                }
                else
                {
                    no = uint.Parse(iconMark[1]);
                }
            }
            var rarityIndex = eduInfos.IndexOf("[rarity]");
            var rarity = rarityIndex >= 0 ? int.Parse(eduInfos[rarityIndex + 1]) : 0;
            var rarityOption = rarity switch
            {
                0 => RarityOption.Common,
                1 => RarityOption.Rare,
                2 => RarityOption.Epic,
                3 => RarityOption.God,
                4 => RarityOption.Legendary,
                5 => RarityOption.Artifact,
                _ => RarityOption.Common
            };
            list.Add(new Equipments
            {
                ItemId = id,
                ItemName = ChineseConverter.Convert(name, ChineseConversionDirection.TraditionalToSimplified),
                NpkPath = npkPath,
                FrameNo = no,
                ItemRarity = rarityOption
            });
        }
        return list;
    }

    public void AnalysisJob(PvfFile pvf) => throw new NotImplementedException();
    public void AnalysisQuest(PvfFile pvf) => throw new NotImplementedException();
    public void AnalysisStackables(PvfFile pvf) => throw new NotImplementedException();

    public List<string> GetPvfPart(List<string> orgStrs, string elementName, string endJugdeStr = "[")
    {
        var list = new List<string>();
        if (orgStrs == null || orgStrs.Count <= 0) return list;
        var index = orgStrs.IndexOf(elementName);
        if (index < 0) return list;
        for (var i = 1; ; i++)
        {
            if (index + i >= orgStrs.Count) break;
            var data = orgStrs[index + i];
            if (!data.StartsWith(endJugdeStr))
                list.Add(data.Trim());
            else
                break;
        }
        return list;
    }

    /*public async Task LoadPvfThreadAsync(string pvfFilename)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await Task.Run(() =>
        {
            using var pvf = new PvfFile(pvfFilename);
            var content = pvf.GetPvfFileByPath("equipment/equipment.lst", Encoding.UTF8);
            AnalysisEquipments(pvf);
        });
    }*/
}



