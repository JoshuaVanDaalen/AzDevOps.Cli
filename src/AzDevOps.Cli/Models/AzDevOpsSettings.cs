using Microsoft.DotNet.PlatformAbstractions;

namespace AzDevOps.Cli.Models;

public class AzDevOpsSettings {
    public string AccessToken { get; set; }
    public string Username { get; set; }
    public AdoEndpoints? Endpoints { get; set; }

}

public sealed partial class AdoEndpoints {
    public string AzureDevOps { get; set; }
    public string VisualStudioSharedPlatformServices { get; set; }
    public string AzureDevOpsSharedPlatformServices { get; set; }
}
