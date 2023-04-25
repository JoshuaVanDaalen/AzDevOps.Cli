using AzDevOps.Cli.Models;
using AzDevOps.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace AzDevOps.Cli.Services;

public sealed class AzDevOpsService : IAzDevOpsService {

    #region Fields

    private readonly IHttpClientFactory _client;
    private readonly GitHttpClient _azDevOpsClient;
    private readonly AzDevOpsSettings _azDevOpsSettings;
    private readonly string _baseUrl;
    private readonly string _credentials;
    private readonly string _clientName;
    private readonly string _apiVersion;

    #endregion Fields

    #region Properties
    #endregion Properties

    #region Constructors

    public AzDevOpsService(IHttpClientFactory httpClientFactory, IConfiguration config
        ) { //, GitHttpClient azDevOpsClient) {
        _client = httpClientFactory;
        //_azDevOpsClient = azDevOpsClient;
        _clientName = "AzDevOpsApi";
        _apiVersion = "api-version=7.0";
        _baseUrl = config.GetValue<string>(nameof(AzDevOpsSettings.BaseUrl));

        //encode personal access token                   
        _credentials = config.GetValue<string>(nameof(AzDevOpsSettings.AccessToken));
    }

    #endregion Constructors

    //public void GetAccount() {


    //    var repoList = _azDevOpsClient.GetRepositoriesAsync().Result;

    //    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(repoList)) {
    //        string name = descriptor.Name;
    //        object value = descriptor.GetValue(repoList);
    //        Console.WriteLine("{0}={1}", name, value);
    //    }


    //}


    /// <summary>
    /// GET https://app.vssps.visualstudio.com/_apis/accounts?api-version=5.1
    /// GET https://app.vssps.visualstudio.com/_apis/accounts?memberId=d6245f20-2af8-44f4-9451-8107cb2767db&api-version=5.1
    /// GET https://app.vssps.visualstudio.com/_apis/accounts?ownerId=d6245f20-2af8-44f4-9451-8107cb2767db&api-version=5.1
    /// </summary>
    /// <param id="1e7eb287-5152-4fb8-8144-29bf0670d98b"></param>
    /// <param isOwner="true"></param>
    /// <returns></returns>
    //public HttpResponseMessage GetAccountAsync(Guid? id, bool isOwner = false) {
    //    var httpClient = _client.CreateClient("BudgetApi");

    //    var requestUri = "_apis/accounts";
    //    var queryString = $"?{_apiVersion}";

    //    if (id is null)
    //        return GetAsync(requestUri, queryString);

    //    queryString = isOwner ? $"&ownerId={id}" : $"&memberId={id}";

    //    return GetAsync(requestUri, queryString);
    //}
    public async Task<IList<Account>?> GetAccountAsync(Guid? id, bool isOwner = false) {
        
        var httpClient = _client.CreateClient("LegacyAzDevOps");
        var requestUri = "_apis/accounts";
        var queryString = isOwner ?
            $"?{_apiVersion}&ownerId={id}" :
            $"?{_apiVersion}&memberId={id}";

        if (id is null)
            queryString = "";

        var response = await httpClient.GetFromJsonAsync<IList<Account>>
            (requestUri: $"{requestUri}{queryString}");

        return response;
    }

    public async Task<IList<Project>?> GetProjectAsync() {

        var httpClient = _client.CreateClient(nameof(AzDevOpsSettings));
        var requestUri = "greenSacrifice/_apis/projects";
        var queryString = $"?{_apiVersion}&stateFilter=All";

        var response = await httpClient.GetAsync(requestUri: $"{requestUri}{queryString}");

        var result = JsonSerializer.Deserialize<List<Project>>(
                (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("value"));
        return result;

    }

    #region Private Helpers

    /// <summary>
    /// Used for get requests in Azure DevOps Api
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="queryString"></param>
    /// <returns>Task.HttpResponseMessage</returns>
    public async Task<HttpResponseMessage> GetAsync(string requestUri, string? queryString) {

        var httpClient = _client.CreateClient(nameof(AzDevOpsSettings));
        //connect to the REST endpoint
        //Console.WriteLine($"Request Uri: {httpClient.BaseAddress}{requestUri}{queryString}");
        return await httpClient.GetAsync(requestUri: $"{requestUri}{queryString}");

    }
    /// <summary>
    /// Internal function that prints the json response for converting into POCO
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="queryString"></param>
    /// <returns>Json object containing the value from the api</returns>
    public JsonElement Get(string requestUri, string? queryString) {

        var httpClient = _client.CreateClient(nameof(AzDevOpsSettings));
        var uri = $"{requestUri}{queryString}";
        Console.WriteLine($"Request Uri: {httpClient.BaseAddress}{uri}");
        //connect to the REST endpoint
        var response = httpClient.GetAsync(requestUri: uri).Result;
        var t = response.Content.ReadFromJsonAsync<dynamic>().Result;
        var result = t.GetProperty("value");

        Console.WriteLine(result);
        return result;

    }

    #endregion Private Helpers
}
