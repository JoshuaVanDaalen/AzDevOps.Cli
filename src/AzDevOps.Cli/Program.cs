﻿using AzDevOps.Cli;
using AzDevOps.Cli.Services;
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
var orgList = ado.GetAccountAsync(null).Result;


Application.Init();

try {
    Application.Run(new AzDevOpsWindow(orgList));
}
finally {
    Application.Shutdown();
}


// Any steps that should happen after user exits the app
//await host.RunAsync();