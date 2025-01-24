using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using pvfLoaderXinyu;

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
    [ObservableProperty]
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

    partial void OnSelectedInventoryItemChanged(Equipments? value)
    {
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

    public async Task LoadDataAsync()
    {
        var equipments = await InventoryManageService.GetEquipmentData();
        InventoryItems = equipments;
    }

    //[RelayCommand]
    public async Task LoadPvfCommandAsync(PvfFile pvfFilename)
    {
        var equipments = await PvfExtensionsService.GetEquipments(pvfFilename);
        InventoryItems = equipments;
        await InventoryManageService.InsertEquipmentData(equipments);
    }
}



