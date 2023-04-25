using AzDevOps.Cli;
using AzDevOps.Cli.Services;
using AzDevOps.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Terminal.Gui;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Production.json")
    .Build();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services
            .AddApplication()
            .AddInfrastructure(config);
    }).Build();

var ado = host.Services.GetRequiredService<IAzDevOpsService>();

var orgList = new List<Organisation>();
var accountList = ado.GetAccountAsync(null).Result;

foreach (var account in accountList) {

    orgList.Add(new Organisation {
        Properties = account,
        Projects = ado.GetProjectAsync(account.AccountName).Result,
        Users = ado.GetUserAsync(account.AccountName).Result,
    });
}


Application.Init();

try {
    Application.Run(new AzDevOpsWindow(orgList));
}
finally {
    Application.Shutdown();
}


// Any steps that should happen after user exits the app
//await host.RunAsync();