using AzDevOps.Cli;
using AzDevOps.Cli.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services
            .AddApplication()
            .AddInfrastructure(config);
    }).Build();

var ado = host.Services.GetRequiredService<IAzDevOpsService>();

var obj = await ado.GetAccountAsync(null);
foreach(var a in obj) {

    Console.WriteLine(a.AccountName);
}
var obj2 = await ado.GetProjectAsync();
Console.WriteLine(obj2);

await host.RunAsync();
