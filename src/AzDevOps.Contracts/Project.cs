using System.Text.Json.Serialization;

namespace AzDevOps.Contracts; 

public partial class Project {
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("revision")]
    public long Revision { get; set; }

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; }

    [JsonPropertyName("lastUpdateTime")]
    public DateTimeOffset LastUpdateTime { get; set; }
}
