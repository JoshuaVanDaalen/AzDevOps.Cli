using AzDevOps.Cli.Models;
using AzDevOps.Cli.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;

namespace AzDevOps.Cli;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config) {

        AzDevOpsSettings azOptions = new();
        config.GetRequiredSection(nameof(AzDevOpsSettings)).Bind(azOptions);

        // Inject Azure DevOps API
        services.AddHttpClient<AzDevOpsSettings>(x => {
            x.BaseAddress = new Uri(uriString: azOptions.BaseUrl);
            x.DefaultRequestHeaders.Accept.Clear();
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            x.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "", azOptions.AccessToken))));

        });
        // Inject Legacy Azure DevOps API
        services.AddHttpClient("LegacyAzDevOps", x => {
            x.BaseAddress = new Uri(uriString: azOptions.LegacyBaseUrl);
            x.DefaultRequestHeaders.Accept.Clear();
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            x.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "", azOptions.AccessToken))));

        });

        // Connect to Azure DevOps Services
        // TODO: Figure out how to inject different rogs into VssConnection
        VssConnection connection = new(new Uri($"{azOptions.BaseUrl}/greenSacrifice"),
            new VssBasicCredential(string.Empty, azOptions.AccessToken));

        services.AddSingleton(connection.GetClient<GitHttpClient>());


        return services;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddSingleton<IAzDevOpsService, AzDevOpsService>();

        return services;
    }
}
