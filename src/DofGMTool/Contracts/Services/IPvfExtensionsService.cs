using DofGMTool.Models;
using pvfLoaderXinyu;
using System.Collections.ObjectModel;

namespace DofGMTool.Contracts.Services;
public interface IPvfExtensionsService
{
    void PreLoadImagePacks();
    //List<string> GetPvfPart(List<string> orgStrs, string elementName, string endJugdeStr);

    /// <summary>
    /// 线程加载pvf文件
    /// </summary>
    /// <param name="pvfFilename"></param>
    /// <returns></returns>
    //Task LoadPvfThreadAsync(string pvfFilename);

    /// <summary>
    /// 解析装备
    /// </summary>
    /// <param name="pvf"></param>
    Task<ObservableCollection<Equipments>> GetEquipments(PvfFile pvf);

    /// <summary>
    /// 解析副本
    /// </summary>
    /// <param name="pvf"></param>
    void AnalysisDungeons(PvfFile pvf);

    /// <summary>
    /// 解析消耗品物品
    /// </summary>
    /// <param name="pvf"></param>
    void AnalysisStackables(PvfFile pvf);

    /// <summary>
    /// 解析职业
    /// </summary>
    /// <param name="pvf"></param>
    void AnalysisJob(PvfFile pvf);

    /// <summary>
    /// 解析技能
    /// </summary>
    /// <param name="pvf"></param>
    Task<ObservableCollection<Skill>> AnalysisSkill(PvfFile pvf);

    /// <summary>
    /// 解析任务
    /// </summary>
    /// <param name="pvf"></param>
    void AnalysisQuest(PvfFile pvf);
}
