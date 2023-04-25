using System.Text.Json.Serialization;

namespace AzDevOps.Contracts;

public sealed partial class Account {
    [JsonPropertyName("AccountId")]
    public Guid AccountId { get; set; }

    [JsonPropertyName("NamespaceId")]
    public Guid NamespaceId { get; set; }

    [JsonPropertyName("AccountName")]
    public string AccountName { get; set; }

    [JsonPropertyName("OrganizationName")]
    public object OrganizationName { get; set; }

    [JsonPropertyName("AccountType")]
    public long AccountType { get; set; }

    [JsonPropertyName("AccountOwner")]
    public Guid AccountOwner { get; set; }

    [JsonPropertyName("CreatedBy")]
    public Guid CreatedBy { get; set; }

    [JsonPropertyName("CreatedDate")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("AccountStatus")]
    public long AccountStatus { get; set; }

    [JsonPropertyName("StatusReason")]
    public object StatusReason { get; set; }

    [JsonPropertyName("LastUpdatedBy")]
    public Guid LastUpdatedBy { get; set; }

    [JsonPropertyName("Properties")]
    public Properties Properties { get; set; }
}
public sealed partial class Properties {
}
