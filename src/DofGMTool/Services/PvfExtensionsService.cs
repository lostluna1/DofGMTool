using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using Microsoft.UI.Xaml.Media.Imaging;
using pvfLoaderXinyu;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Text;

namespace DofGMTool.Services;
public class PvfExtensionsService : IPvfExtensionsService
{
    private readonly ConcurrentDictionary<string, WeakReference<BitmapImage>> _imageCache = new();
    public void PreLoadImagePacks()
    {
        ImagePacks.ImagePacksPath = "D:\\DOF\\1031客户端\\ImagePacks2";
        if (string.IsNullOrWhiteSpace(ImagePacks.ImagePacksPath)) return;
        string[] files = Directory.GetFiles(ImagePacks.ImagePacksPath, "sprite_item*");

        foreach (string file in files)
        {
            var npk = new NpkFile(file);
            if (npk == null || npk.NpkFiles.Count <= 0) continue;
            /*if (NPKHelper._npkIndexes!=null)
            {
            }*/
            try
            {
                NPKHelper._npkIndexes?.AddRange(npk.NpkFiles);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*Task.Run(() =>
        {
           
            var files = Directory.GetFiles(ImagePacks.ImagePacksPath, "sprite_item*");

            foreach (var file in files)
            {
                var npk = new NpkFile(file);
                if (npk == null || npk.NpkFiles.Count <= 0) continue;
                *//*if (NPKHelper._npkIndexes!=null)
                {
                }*//*
                try
                {
                    NPKHelper._npkIndexes?.AddRange(npk.NpkFiles);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        });*/
    }
    public void AnalysisDungeons(PvfFile pvf) => throw new NotImplementedException();

    public async Task<ObservableCollection<Equipments>> GetEquipments(PvfFile pvf)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var _pvfEncoding = Encoding.GetEncoding("gb2312");
        string? itemDic = pvf.GetPvfFileByPath("equipment/equipment.lst", Encoding.UTF8);
        if (itemDic == null)
        {
            return new ObservableCollection<Equipments>();
        }

        var itemArr = itemDic.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();
        int total = itemArr.Count;

        var list = new ConcurrentBag<Equipments>();
        IEnumerable<Task> tasks = itemArr.Select(async item =>
        {
            string[] arr = item.Split("\t", StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 1)
            {
                return;
            }

            string id = arr[0];
            string path = arr[1].Replace("`", "");
            string? equipEdu = pvf.GetPvfFileByPath($"equipment/{path}", Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(equipEdu))
            {
                return;
            }

            var eduInfos = equipEdu.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith("#")).ToList();
            if (eduInfos.Count <= 0)
            {
                return;
            }

            int index = eduInfos.IndexOf("[name]");
            string name = eduInfos[index + 1].Replace("`", "").Replace($"<3::name_{id}", "").Replace(">", "");
            name = Encoding.GetEncoding("gb2312").GetString(_pvfEncoding.GetBytes(name));
            List<string> iconMark = GetPvfPart(eduInfos, "[icon]");
            if (iconMark.Count <= 0)
            {
                iconMark = GetPvfPart(eduInfos, "[icon mark]");
            }

            string npkPath = string.Empty;
            uint no = 0u;
            if (iconMark.Count > 0)
            {
                npkPath = iconMark[0].Replace("`", "");
                no = iconMark[1].Contains("`") ? uint.Parse(iconMark[2]) : uint.Parse(iconMark[1]);
            }

            int rarityIndex = eduInfos.IndexOf("[rarity]");
            int rarity = rarityIndex >= 0 ? int.Parse(eduInfos[rarityIndex + 1]) : 0;
            RarityOption rarityOption = rarity switch
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
        });

        await Task.WhenAll(tasks);

        return new ObservableCollection<Equipments>(list);
    }


    public void AnalysisJob(PvfFile pvf) => throw new NotImplementedException();
    public void AnalysisQuest(PvfFile pvf) => throw new NotImplementedException();
    public void AnalysisStackables(PvfFile pvf) => throw new NotImplementedException();

    public List<string> GetPvfPart(List<string> orgStrs, string elementName, string endJugdeStr = "[")
    {
        var list = new List<string>();
        if (orgStrs == null || orgStrs.Count <= 0) return list;
        int index = orgStrs.IndexOf(elementName);
        if (index < 0) return list;
        for (int i = 1; ; i++)
        {
            if (index + i >= orgStrs.Count) break;
            string data = orgStrs[index + i];
            if (!data.StartsWith(endJugdeStr))
                list.Add(data.Trim());
            else
                break;
        }
        return list;
    }


}



