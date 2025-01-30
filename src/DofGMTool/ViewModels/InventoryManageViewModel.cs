using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using pvfLoaderXinyu;
using System.Collections.ObjectModel;

namespace DofGMTool.ViewModels;

public partial class InventoryManageViewModel : ObservableObject
{
    public IInventoryManageService InventoryManageService
    {
        get;
    }
    public IPvfExtensionsService PvfExtensionsService
    {
        get;
    }
    [ObservableProperty] // 比如这个可观察的集合,我只要修改它,前台UI就会自动更新
    public partial ObservableCollection<RarityOption>? RarityOptions
    {
        get; set;
    }

    [ObservableProperty]
    public partial ObservableCollection<Equipments>? InventoryItems
    {
        get; set;
    }

    [ObservableProperty]
    public partial Equipments? SelectedInventoryItem
    {
        get; set;
    }

    [ObservableProperty]
    public partial int SelectedPageIndex { get; set; } = 1;

    [ObservableProperty]
    public partial bool IsLoading { get; set; } = false;
    /// <summary>
    /// 总页数
    /// </summary>
    [ObservableProperty]
    public partial int NumberOfPages { get; set; } = 100;

    [ObservableProperty]
    public partial string ItemId { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ItemName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial RarityOption? SelectedRarityOption { get; set; }

    partial void OnSelectedInventoryItemChanged(Equipments? value)
    {
    }
    partial void OnSelectedPageIndexChanged(int oldValue, int newValue)
    {
        _ = LoadDataAsync();
        //var npkPaths = InventoryItems.Select(item => item.NpkPath).Where(path => !string.IsNullOrWhiteSpace(path));
        //PvfExtensionsService.PreLoadImagePacks(npkPaths);
    }
    public InventoryManageViewModel(IPvfExtensionsService pvfExtensionsService, IInventoryManageService inventoryManageService)
    {
        PvfExtensionsService = pvfExtensionsService;
        RarityOptions =
        [
            RarityOption.Common,
            RarityOption.Rare,
            RarityOption.Epic,
            RarityOption.Legendary,
            RarityOption.Artifact,
            RarityOption.God
        ];
        InventoryManageService = inventoryManageService;

        _ = LoadDataAsync();



    }

    public async Task Delete(string id)
    {
        await InventoryManageService.DeleteEquipmentData(id);
    }

    [RelayCommand]
    private void ResetOption()
    {
        ItemId = string.Empty;
        ItemName = string.Empty;
        SelectedRarityOption = null;
    }


    [RelayCommand]
    public async Task LoadDataAsync()
    {
        const int pageSize = 30;
        (ObservableCollection<Equipments> Equipments, int TotalCount) result = await InventoryManageService.GetEquipmentDataPaged(SelectedPageIndex, pageSize, ItemId, ItemName, SelectedRarityOption);
        InventoryItems = result.Equipments;
        NumberOfPages = (int)Math.Ceiling((double)result.TotalCount / pageSize);
        //foreach (var item in InventoryItems)
        //{
        //    if (!string.IsNullOrEmpty( item.SkillLevelUp))
        //    {
        //       var a = InventoryManageService.ParseSkillLevelUpInfo(item.SkillLevelUp);
        //    }

        //}
        if (InventoryItems != null)
        {
            //var npkPaths = InventoryItems.Select(item => item.NpkPath).Where(path => !string.IsNullOrWhiteSpace(path));
            //PvfExtensionsService.PreLoadImagePacks();
            //NPKHelper.GetBitMap(InventoryItems);
            NPKHelper.GetBitMaps(InventoryItems);

        }
    }

    //[RelayCommand]
    public async Task LoadPvfCommandAsync(PvfFile pvfFilename)
    {
        IsLoading = true;
        ObservableCollection<SkillInfo> skills = await PvfExtensionsService.AnalysisSkill(pvfFilename);
        await InventoryManageService.InsertSkillData(skills);
        ObservableCollection<Equipments> equipments = await PvfExtensionsService.GetEquipments(pvfFilename);

        PvfExtensionsService.PreLoadImagePacks();
        NPKHelper.GetBitMap(equipments);
        await InventoryManageService.InsertEquipmentData(equipments);
        await LoadDataAsync();
        /*await Task.Run(async() => {
            var skills = await PvfExtensionsService.AnalysisSkill(pvfFilename);
            await InventoryManageService.InsertSkillData(skills);
            ObservableCollection<Equipments> equipments = await PvfExtensionsService.GetEquipments(pvfFilename);

            PvfExtensionsService.PreLoadImagePacks();
            NPKHelper.GetBitMap(equipments);
            await InventoryManageService.InsertEquipmentData(equipments);
            await LoadDataAsync();
        });*/
        IsLoading = false;
    }
}



