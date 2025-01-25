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

        PvfExtensionsService.PreLoadImagePacks();
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

        if (InventoryItems != null)
        {
            NPKHelper.GetBitMap(InventoryItems);

        }
    }

    //[RelayCommand]
    public async Task LoadPvfCommandAsync(PvfFile pvfFilename)
    {
        ObservableCollection<Equipments> equipments = await PvfExtensionsService.GetEquipments(pvfFilename);
        await InventoryManageService.InsertEquipmentData(equipments);
        await LoadDataAsync();
    }
}



