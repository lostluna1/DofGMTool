using CommunityToolkit.Mvvm.ComponentModel;

namespace DofGMTool.Contracts.Services;

public interface IApiService
{
    Task<ApiResponse<T>> GetAsync<T>(string uri, bool requiresToken = false);
    Task<ApiResponse<T>> PostAsync<T>(string uri, object data, bool requiresToken = false);
    Task<ApiResponse<T>> PostAsync<T>(string uri, HttpContent content, bool requiresToken = false);
    Task<ApiResponse<T>> PutAsync<T>(string uri, object data, bool requiresToken = false);
    Task<ApiResponse<T>> DeleteAsync<T>(string endpoint, long id, bool requiresToken = false);
    void SetToken(string token);
}

public partial class ApiResponse<T> : ObservableValidator
{
    [ObservableProperty]
    public partial bool Success { get; set; }

    [ObservableProperty]
    public partial string? Code { get; set; }

    [ObservableProperty]
    public partial string? Msg { get; set; }

    [ObservableProperty]
    public partial T? Data { get; set; }
}