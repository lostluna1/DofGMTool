﻿using CommunityToolkit.Mvvm.ComponentModel;

using DofGMTool.Contracts.Services;
using DofGMTool.ViewModels;
using DofGMTool.Views;

using Microsoft.UI.Xaml.Controls;

namespace DofGMTool.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = [];

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<InventoryManageViewModel, InventoryManagePage>();
        Configure<CharacterManageViewModel, CharacterManagePage>();
        Configure<MailManageViewModel, MailManagePage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            string key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            Type type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
