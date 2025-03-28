using DofGMTool.Contracts.Services;
using DofGMTool.Core.Helpers;
using DofGMTool.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace DofGMTool.Services;
public class ApiSettings
{
    public string? BaseUrl
    {
        get; set;
    }
}
public class HttpService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private string? _token;
    public HttpService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _apiBaseUrl = apiSettings.Value.BaseUrl!;
        var connectionInfo = GlobalVariables.Instance.ConnectionInfo;
        if (connectionInfo?.Ip is not null)
        {
            _apiBaseUrl = $"http://{connectionInfo.Ip}:41817";
        }
    }
    public void SetToken(string token)
    {
        _token = token;
    }
    private void AddAuthorizationHeader()
    {
        if (!string.IsNullOrEmpty(_token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }
    }

    public async Task<ApiResponse<T>> GetAsync<T>(string uri, bool requiresToken = false)
    {
        if (requiresToken)
        {
            AddAuthorizationHeader();
        }
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiBaseUrl}{uri}");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return await Json.ToObjectAsync<ApiResponse<T>>(jsonResponse);
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<ApiResponse<T>> PostAsync<T>(string uri, object data, bool requiresToken = false)
    {
        if (requiresToken)
        {
            AddAuthorizationHeader();
        }
        string jsonRequestBody = await Json.StringifyAsync(data);
        StringContent content = new(jsonRequestBody, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync($"{_apiBaseUrl}{uri}", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return await Json.ToObjectAsync<ApiResponse<T>>(jsonResponse);
    }
    public async Task<ApiResponse<T>> PostAsync<T>(string uri, HttpContent content, bool requiresToken = false)
    {
        if (requiresToken)
        {
            AddAuthorizationHeader();
        }

        HttpResponseMessage response = await _httpClient.PostAsync($"{_apiBaseUrl}{uri}", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return await Json.ToObjectAsync<ApiResponse<T>>(jsonResponse);
    }


    public async Task<ApiResponse<T>> PutAsync<T>(string uri, object data, bool requiresToken = false)
    {
        if (requiresToken)
        {
            AddAuthorizationHeader();
        }
        string jsonRequestBody = await Json.StringifyAsync(data);
        StringContent content = new(jsonRequestBody, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PutAsync($"{_apiBaseUrl}{uri}", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return await Json.ToObjectAsync<ApiResponse<T>>(jsonResponse);
    }

    public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint, long id, bool requiresToken = false)
    {
        if (requiresToken)
        {
            AddAuthorizationHeader();
        }
        string uri = $"{_apiBaseUrl}{endpoint}?id={id}";
        HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        return await Json.ToObjectAsync<ApiResponse<T>>(jsonResponse);
    }


}
