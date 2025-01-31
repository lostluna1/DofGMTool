﻿using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using pvfLoaderXinyu;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace DofGMTool.Services;
public class PvfExtensionsService : IPvfExtensionsService
{

    public void PreLoadImagePacks()
    {
        ImagePacks.ImagePacksPath = NPKHelper.LoadImagePacks2Path() ?? string.Empty;//"D:\\DOF\\ImagePacks2";
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

    }
    public void AnalysisDungeons(PvfFile pvf) => throw new NotImplementedException();

    //public async Task<ObservableCollection<Equipments>> GetEquipments(PvfFile pvf)
    //{
    //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    //    var _pvfEncoding = Encoding.GetEncoding("gb2312");
    //    string? itemDic = pvf.GetPvfFileByPath("equipment/equipment.lst", Encoding.UTF8);
    //    if (itemDic == null)
    //    {
    //        return new ObservableCollection<Equipments>();
    //    }

    //    var itemArr = itemDic.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();
    //    int total = itemArr.Count;

    //    var list = new ConcurrentBag<Equipments>();
    //    var tasks = itemArr.Select(async item =>
    //    {
    //        string[] arr = item.Split("\t", StringSplitOptions.RemoveEmptyEntries);
    //        if (arr.Length < 1)
    //        {
    //            return;
    //        }

    //        string id = arr[0];
    //        string path = arr[1].Replace("`", "");
    //        string? equipEdu = pvf.GetPvfFileByPath($"equipment/{path}", Encoding.UTF8);
    //        if (string.IsNullOrWhiteSpace(equipEdu))
    //        {
    //            return;
    //        }

    //        var eduInfos = equipEdu.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith("#")).ToList();
    //        if (eduInfos.Count <= 0)
    //        {
    //            return;
    //        }

    //        int index = eduInfos.IndexOf("[name]");
    //        if (index < 0 || index + 1 >= eduInfos.Count)
    //        {
    //            return;
    //        }
    //        //var index = eduInfos.IndexOf("[name]");
    //        var name = eduInfos[index + 1].Replace("`", "");

    //        name = Encoding.GetEncoding("gb2312").GetString(_pvfEncoding.GetBytes(name));
    //        /*string name = eduInfos[index + 1];
    //        var sb = new StringBuilder(name);
    //        sb.Replace("`", "").Replace($"<3::name_{id}", "").Replace(">", "");
    //        name = Encoding.GetEncoding("gb2312").GetString(_pvfEncoding.GetBytes(name.ToString()));*/

    //        List<string> iconMark = GetPvfPart(eduInfos, "[icon]");
    //        if (iconMark.Count <= 0)
    //        {
    //            iconMark = GetPvfPart(eduInfos, "[icon mark]");
    //        }

    //        string npkPath = string.Empty;
    //        uint no = 0u;
    //        if (iconMark.Count > 0)
    //        {
    //            npkPath = iconMark[0].Replace("`", "");
    //            no = iconMark[1].Contains("`") ? uint.Parse(iconMark[2]) : uint.Parse(iconMark[1]);
    //        }

    //        int rarityIndex = eduInfos.IndexOf("[rarity]");
    //        int rarity = rarityIndex >= 0 ? int.Parse(eduInfos[rarityIndex + 1]) : 0;
    //        RarityOption rarityOption = rarity switch
    //        {
    //            0 => RarityOption.Common,
    //            1 => RarityOption.Rare,
    //            2 => RarityOption.Epic,
    //            3 => RarityOption.God,
    //            4 => RarityOption.Legendary,
    //            5 => RarityOption.Artifact,
    //            _ => RarityOption.Common
    //        };

    //        list.Add(new Equipments
    //        {
    //            ItemId = id,
    //            ItemName = ChineseConverter.Convert(name, ChineseConversionDirection.TraditionalToSimplified),
    //            NpkPath = npkPath,
    //            FrameNo = no,
    //            ItemRarity = rarityOption
    //        });
    //    });

    //    await Task.WhenAll(tasks);

    //    // 手动调用垃圾回收器
    //    GC.Collect();
    //    GC.WaitForPendingFinalizers();
    //    GC.Collect();
    //    pvf.Dispose();
    //    return new ObservableCollection<Equipments>(list);
    //}
    public async Task<ObservableCollection<Equipments>> GetEquipments(PvfFile pvf)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var _pvfEncoding = Encoding.GetEncoding("gb2312");
        string? itemDic = pvf.GetPvfFileByPath("equipment/equipment.lst", Encoding.UTF8);
        string? skillListPath = pvf.GetPvfFileByPath("skill/swordmanskill.lst", Encoding.UTF8);
        if (itemDic == null)
        {
            return [];
        }

        var itemArr = itemDic.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();
        int total = itemArr.Count;

        var list = new ConcurrentBag<Equipments>();
        IEnumerable<Task> tasks = itemArr.Select(async item =>
        {
            try
            {
                string[] arr = item.Split("\t", StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length < 1)
                {
                    return;
                }

                string id = arr[0];
                if (id=="10400")
                {
                    Debug.WriteLine("10400");
                }
                string path = arr[1].Replace("`", "");
                string? equipEdu = pvf.GetPvfFileByPath($"equipment/{path}", Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(equipEdu))
                {
                    return;
                }

                Dictionary<string, List<string>> parsedContent = ParsePvfContent(equipEdu);

                string name = parsedContent.ContainsKey("[name]") && parsedContent["[name]"].Any() ? parsedContent["[name]"].First().Replace("`", "") : string.Empty;
                name = Encoding.GetEncoding("gb2312").GetString(_pvfEncoding.GetBytes(name));

                List<string> iconMark = parsedContent.ContainsKey("[icon]") ? parsedContent["[icon]"] : [];
                if (iconMark.Count <= 0)
                {
                    iconMark = parsedContent.ContainsKey("[icon mark]") ? parsedContent["[icon mark]"] : [];
                }

                string npkPath = string.Empty;
                uint no = 0u;
                if (iconMark.Count > 0)
                {
                    npkPath = iconMark[0].Replace("`", "");
                    no = iconMark[1].Contains("`") ? uint.Parse(iconMark[2]) : uint.Parse(iconMark[1]);
                }

                int rarity = parsedContent.ContainsKey("[rarity]") && parsedContent["[rarity]"].Any() ? int.Parse(parsedContent["[rarity]"].First()) : 0;
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
                Dictionary<string, string> tagTranslations = TagDictionary.EquipmentTypeTranslations;
                string equipmentType = parsedContent.ContainsKey("[equipment type]") ? tagTranslations.GetValueOrDefault(parsedContent["[equipment type]"].First().Replace("`", ""), string.Empty) : string.Empty;
                string? usableJob = parsedContent.ContainsKey("[usable job]") ? TagDictionary.UsableJobTranslations.GetValueOrDefault(parsedContent["[usable job]"].First().Replace("`", "")) : string.Empty;
                string? attachType = parsedContent.ContainsKey("[attach type]") ? TagDictionary.AttachTypeTranslations.GetValueOrDefault(parsedContent["[attach type]"].First().Replace("`", "")) : string.Empty;
                string? itemGroupName = parsedContent.ContainsKey("[item group name]") ? TagDictionary.EquipmentGroupTypeTranslations.GetValueOrDefault(parsedContent["[item group name]"].First().Replace("`", "")) : string.Empty;
                string? elementalProperty = parsedContent.ContainsKey("[elemental property]") ? TagDictionary.ElementTranslations.GetValueOrDefault(parsedContent["[elemental property]"].First().Replace("`", "")) : string.Empty;


                string convertedEquipmentType = string.IsNullOrEmpty(equipmentType) ? equipmentType : ChineseConverter.Convert(equipmentType, ChineseConversionDirection.TraditionalToSimplified);
                usableJob = string.IsNullOrEmpty(usableJob) ? usableJob : ChineseConverter.Convert(usableJob, ChineseConversionDirection.TraditionalToSimplified);
                attachType = string.IsNullOrEmpty(attachType) ? attachType : ChineseConverter.Convert(attachType, ChineseConversionDirection.TraditionalToSimplified);
                itemGroupName = string.IsNullOrEmpty(itemGroupName) ? itemGroupName : ChineseConverter.Convert(itemGroupName, ChineseConversionDirection.TraditionalToSimplified);
                elementalProperty = string.IsNullOrEmpty(elementalProperty) ? elementalProperty : ChineseConverter.Convert(elementalProperty, ChineseConversionDirection.TraditionalToSimplified);

                string skillLevelUp = parsedContent.ContainsKey("[skill levelup]") ? string.Join("\n", parsedContent["[skill levelup]"]) : string.Empty;
                string darkAttack = parsedContent.ContainsKey("[dark attack]") ? string.Join("\n", parsedContent["[dark attack]"].First()) : string.Empty;
                string lightAttack = parsedContent.ContainsKey("[light attack]") ? string.Join("\n", parsedContent["[light attack]"].First()) : string.Empty;
                string waterAttack = parsedContent.ContainsKey("[water attack]") ? string.Join("\n", parsedContent["[water attack]"].First()) : string.Empty;
                string fireAttack = parsedContent.ContainsKey("[fire attack]") ? string.Join("\n", parsedContent["[fire attack]"].First()) : string.Empty;

                list.Add(new Equipments
                {
                    ItemId = id,
                    ItemName = ChineseConverter.Convert(name, ChineseConversionDirection.TraditionalToSimplified),
                    NpkPath = npkPath,
                    FrameNo = no,
                    ItemRarity = rarityOption,
                    Description = parsedContent.ContainsKey("[basic explain]") ? string.Join("\n", parsedContent["[basic explain]"]) : string.Empty,
                    DetailDescription = parsedContent.ContainsKey("[detail explain]") ? string.Join("\n", parsedContent["[detail explain]"]) : string.Empty,
                    FireAttack = fireAttack,
                    LightAttack = lightAttack,
                    DarkAttack = darkAttack,
                    WaterAttack = waterAttack,
                    FlavorText = parsedContent.ContainsKey("[flavor text]") ? string.Join("\n", parsedContent["[flavor text]"]) : string.Empty,
                    Grade = parsedContent.ContainsKey("[grade]") ? int.Parse(parsedContent["[grade]"].First()) : 0,
                    MinimumLevel = parsedContent.ContainsKey("[minimum level]") ? int.Parse(parsedContent["[minimum level]"].First()) : 0,
                    MagicalAttack = parsedContent.ContainsKey("[magical attack]") ? int.Parse(parsedContent["[magical attack]"].First()) : 0,
                    PhysicalAttack = parsedContent.ContainsKey("[physical attack]") ? int.Parse(parsedContent["[physical attack]"].First()) : 0,
                    CastSpeed = parsedContent.ContainsKey("[cast speed]") ? int.Parse(parsedContent["[cast speed]"].First()) : 0,
                    Price = parsedContent.ContainsKey("[price]") ? int.Parse(parsedContent["[price]"].First()) : 0,
                    EquipmentPhysicalAttack = parsedContent.ContainsKey("[equipment physical attack]") ? parsedContent["[equipment physical attack]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    EquipmentMagicalAttack = parsedContent.ContainsKey("[equipment magical attack]") ? parsedContent["[equipment magical attack]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    SeparateAttack = parsedContent.ContainsKey("[separate attack]") ? parsedContent["[separate attack]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    MagicalCriticalHit = parsedContent.ContainsKey("[magical critical hit]") ? int.Parse(parsedContent["[magical critical hit]"].First()) : 0,
                    PhysicalCriticalHit = parsedContent.ContainsKey("[physical critical hit]") ? int.Parse(parsedContent["[physical critical hit]"].First()) : 0,
                    PhysicalDefense = parsedContent.ContainsKey("[physical defense]") ? int.Parse(parsedContent["[physical defense]"].First()) : 0,
                    EquipmentType = convertedEquipmentType,
                    Weight = parsedContent.ContainsKey("[weight]") ? int.Parse(parsedContent["[weight]"].First()) : 0,
                    EquipmentPhysicalDefense = parsedContent.ContainsKey("[equipment physical defense]") ? parsedContent["[equipment physical defense]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    EquipmentMagicDefense = parsedContent.ContainsKey("[equipment magical defense]") ? parsedContent["[equipment magical defense]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,

                    MagicalDefense = parsedContent.ContainsKey("[magical defense]") ? int.Parse(parsedContent["[magical defense]"].First()) : 0,
                    UsableJob = usableJob,
                    AttachType = attachType,
                    SubType = parsedContent.ContainsKey("[sub type]") ? parsedContent["[sub type]"].First() : string.Empty,
                    Durability = parsedContent.ContainsKey("[durability]") ? int.Parse(parsedContent["[durability]"].First()) : 0,
                    ItemGroupName = itemGroupName,
                    ElementalProperty = elementalProperty,

                    HpMax = parsedContent.ContainsKey("[HP MAX]") ? parsedContent["[HP MAX]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    MpMax = parsedContent.ContainsKey("[MP MAX]") ? parsedContent["[MP MAX]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    AttackSpeed = parsedContent.ContainsKey("[attack speed]") ? parsedContent["[attack speed]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    MoveSpeed = parsedContent.ContainsKey("[move speed]") ? parsedContent["[move speed]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    Stuck = parsedContent.ContainsKey("[stuck]") ? parsedContent["[stuck]"].Select(s => s.Split('\t').Select(int.Parse).Max()).FirstOrDefault() : null,
                    SkillLevelUp = skillLevelUp
                });

            }
            catch (FormatException ex)
            {
                // 记录出错的 item 信息
                Console.WriteLine($"Error parsing item: {item}");
                Console.WriteLine(ex);
            }
        });

        await Task.WhenAll(tasks);

        // 手动调用垃圾回收器
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        //pvf.Dispose();
        return new ObservableCollection<Equipments>(list);
    }
    /*    光属性强化
    [light attack]
    火属性强化
    [fire attack]
    水属性强化
    [water attack]
    暗属性强化
    [dark attack]*/
    public Dictionary<string, List<string>> ParsePvfContent(string content)
    {
        var result = new Dictionary<string, List<string>>();
        string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string? currentTag = null;
        var validTags = new HashSet<string>
    {
        "[name]", "[basic explain]", "[flavor text]", "[grade]", "[rarity]", "[minimum level]",
        "[magical attack]", "[cast speed]", "[price]", "[equipment physical attack]","[icon]","[icon mark]",
        "[equipment magical attack]","[physical attack]", "[separate attack]","[physical critical hit]", "[magical critical hit]","[detail explain]","[flavor text]",
        "[skill levelup]", "[equipment type]", "[weight]", "[equipment physical defense]", "[magical defense]",
        "[usable job]", "[attach type]", "[sub type]", "[durability]", "[item group name]", "[elemental property]",
        "[attack speed]","[move speed]","[stuck]","[HP MAX]","[MP MAX]","[light attack]","[fire attack]","[water attack]","[dark attack]","[physical defense]",
        "[equipment magical defense]"
    };

        var skipTags = new HashSet<string>
    {
        "[level linear ability]"
    };

        bool skipSection = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                if (skipTags.Contains(line.Trim()))
                {
                    skipSection = true;
                    continue;
                }

                if (line.Trim() == "[/level linear ability]")
                {
                    skipSection = false;
                    continue;
                }

                if (skipSection)
                {
                    continue;
                }

                currentTag = line.Trim();
                if (validTags.Contains(currentTag))
                {
                    if (!result.ContainsKey(currentTag))
                    {
                        result[currentTag] = [];
                    }
                }
                else
                {
                    currentTag = null;
                }
            }
            else if (currentTag != null && !skipSection)
            {
                result[currentTag].Add(line.Trim());
            }
        }

        return result;
    }
    public Dictionary<string, List<string>> ParsePvfContent(List<string> contentLines)
    {
        var result = new Dictionary<string, List<string>>();
        string? currentTag = null;
        var validTags = new HashSet<string>
    {
        "[name]", "[name2]", "[explain]", "[basic explain]", "[feature skill index]", "[purchase cost]",
        "[required level]", "[required level range]", "[type]", "[skill class]", "[maximum level]",
        "[growtype maximum level]", "[skill fitness growtype]", "[consume MP]", "[casting time]",
        "[cool time]", "[durability decrease rate]", "[weapon effect type]", "[icon]", "[command]",
        "[command key explain]", "[static data]", "[level info]", "[pvp]", "[level property]",
        "[skill preloading image]"
    };

        foreach (string line in contentLines)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                currentTag = line.Trim();
                if (validTags.Contains(currentTag))
                {
                    if (!result.ContainsKey(currentTag))
                    {
                        result[currentTag] = [];
                    }
                }
                else
                {
                    currentTag = null;
                }
            }
            else if (currentTag != null)
            {
                result[currentTag].Add(line.Trim());
            }
        }

        return result;
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

    public async Task<ObservableCollection<SkillInfo>> AnalysisSkill(PvfFile pvf)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var _pvfEncoding = Encoding.GetEncoding("gb2312");

        // 获取 skill 目录下所有以 skill.lst 结尾的文件路径
        var skillListPaths = pvf.headerTreeCache.Keys
            .Where(path => path.StartsWith("skill/") && path.EndsWith(".lst"))
            .ToList();

        var skills = new ConcurrentBag<SkillInfo>();
        IEnumerable<Task> tasks = skillListPaths.Select(async skillListPath =>
        {
            string? skillListContent = pvf.GetPvfFileByPath(skillListPath, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(skillListContent))
            {
                return;
            }

            var skillFiles = skillListContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();

            foreach (string? skillFile in skillFiles)
            {
                string[] arr = skillFile.Split("\t", StringSplitOptions.RemoveEmptyEntries);
                if (arr[0] == "21")
                {
                    Debug.WriteLine("21");
                }
                if (arr.Length < 2)
                {
                    continue;
                }

                string path = arr[1].Replace("`", "");
                string? skillContent = pvf.GetPvfFileByPath($"skill/{path}", Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(skillContent))
                {
                    continue;
                }

                var skillArr = skillContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Where(t => !t.StartsWith('#')).ToList();

                Dictionary<string, List<string>> parsedContent = ParsePvfContent(skillArr);

                var skill = new SkillInfo
                {
                    SkillId = arr[0],
                    Name = parsedContent.ContainsKey("[name]") && parsedContent["[name]"].Any() ? parsedContent["[name]"].First().Replace("`", "") : string.Empty,
                    Name2 = parsedContent.ContainsKey("[name2]") && parsedContent["[name2]"].Any() ? parsedContent["[name2]"].First().Replace("`", "") : string.Empty,
                    Explain = parsedContent.ContainsKey("[explain]") ? string.Join("\n", parsedContent["[explain]"]) : string.Empty,
                    BasicExplain = parsedContent.ContainsKey("[basic explain]") ? string.Join("\n", parsedContent["[basic explain]"]) : string.Empty,
                    FeatureSkillIndex = parsedContent.ContainsKey("[feature skill index]") && parsedContent["[feature skill index]"].Any() ? parsedContent["[feature skill index]"].First() : string.Empty,
                    PurchaseCost = parsedContent.ContainsKey("[purchase cost]") && parsedContent["[purchase cost]"].Any() ? parsedContent["[purchase cost]"].First() : string.Empty,
                    RequiredLevel = parsedContent.ContainsKey("[required level]") && parsedContent["[required level]"].Any() ? parsedContent["[required level]"].First() : string.Empty,
                    RequiredLevelRange = parsedContent.ContainsKey("[required level range]") && parsedContent["[required level range]"].Any() ? parsedContent["[required level range]"].First() : string.Empty,
                    Type = parsedContent.ContainsKey("[type]") && parsedContent["[type]"].Any() ? parsedContent["[type]"].First().Replace("`", "") : string.Empty,
                    SkillClass = parsedContent.ContainsKey("[skill class]") && parsedContent["[skill class]"].Any() ? parsedContent["[skill class]"].First() : string.Empty,
                    MaximumLevel = parsedContent.ContainsKey("[maximum level]") && parsedContent["[maximum level]"].Any() ? parsedContent["[maximum level]"].First() : string.Empty,
                    GrowtypeMaximumLevel = parsedContent.ContainsKey("[growtype maximum level]") && parsedContent["[growtype maximum level]"].Any() ? FormatList(parsedContent["[growtype maximum level]"].First()) : string.Empty,
                    SkillFitnessGrowtype = parsedContent.ContainsKey("[skill fitness growtype]") && parsedContent["[skill fitness growtype]"].Any() ? parsedContent["[skill fitness growtype]"].First() : string.Empty,
                    ConsumeMP = parsedContent.ContainsKey("[consume MP]") && parsedContent["[consume MP]"].Any() ? FormatList(parsedContent["[consume MP]"].First()) : string.Empty,
                    CastingTime = parsedContent.ContainsKey("[casting time]") && parsedContent["[casting time]"].Any() ? FormatList(parsedContent["[casting time]"].First()) : string.Empty,
                    CoolTime = parsedContent.ContainsKey("[cool time]") && parsedContent["[cool time]"].Any() ? FormatList(parsedContent["[cool time]"].First()) : string.Empty,
                    DurabilityDecreaseRate = parsedContent.ContainsKey("[durability decrease rate]") && parsedContent["[durability decrease rate]"].Any() ? parsedContent["[durability decrease rate]"].First() : string.Empty,
                    WeaponEffectType = parsedContent.ContainsKey("[weapon effect type]") && parsedContent["[weapon effect type]"].Any() ? parsedContent["[weapon effect type]"].First().Replace("`", "") : string.Empty,
                    Icon = parsedContent.ContainsKey("[icon]") && parsedContent["[icon]"].Any() ? parsedContent["[icon]"].First().Replace("`", "") : string.Empty,
                    Command = parsedContent.ContainsKey("[command]") ? string.Join("\n", parsedContent["[command]"]) : string.Empty,
                    CommandKeyExplain = parsedContent.ContainsKey("[command key explain]") ? string.Join("\n", parsedContent["[command key explain]"]) : string.Empty,
                    StaticData = parsedContent.ContainsKey("[static data]") && parsedContent["[static data]"].Any() ? FormatList(parsedContent["[static data]"].First()) : string.Empty,
                    LevelInfo = parsedContent.ContainsKey("[level info]") && parsedContent["[level info]"].Any() ? FormatList(parsedContent["[level info]"].First()) : string.Empty,
                    PvpCoolTime = parsedContent.ContainsKey("[pvp]") && parsedContent["[pvp]"].Any() ? FormatList(parsedContent["[pvp]"].First()) : string.Empty,
                    PvpLevelInfo = parsedContent.ContainsKey("[pvp]") && parsedContent["[pvp]"].Count > 1 ? FormatList(parsedContent["[pvp]"][1]) : string.Empty,
                    LevelProperty = parsedContent.ContainsKey("[level property]") ? string.Join("\n", parsedContent["[level property]"]) : string.Empty,
                    SkillPreloadingImage = parsedContent.ContainsKey("[skill preloading image]") ? string.Join("\n", parsedContent["[skill preloading image]"]) : string.Empty,
                    SourceList = ExtractJobName(skillListPath)
                };

                skills.Add(skill);
            }
        });

        await Task.WhenAll(tasks);

        // 手动调用垃圾回收器
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        //pvf.Dispose();

        return new ObservableCollection<SkillInfo>(skills);
    }
    private string FormatList(string input)
    {
        string[] items = input.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return $"[{string.Join(",", items)}]";
    }

    private string ExtractJobName(string skillListPath)
    {
        string fileName = Path.GetFileNameWithoutExtension(skillListPath);
        return fileName.Replace("skill", "", StringComparison.OrdinalIgnoreCase);
    }



}



