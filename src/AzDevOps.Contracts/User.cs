using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzDevOps.Contracts;


public partial class User {
    [JsonPropertyName("subjectKind")]
    public string SubjectKind { get; set; }

    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    [JsonPropertyName("principalName")]
    public string PrincipalName { get; set; }

    [JsonPropertyName("mailAddress")]
    public string MailAddress { get; set; }

    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    [JsonPropertyName("originId")]
    public Guid OriginId { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("descriptor")]
    public string Descriptor { get; set; }

    [JsonPropertyName("metaType")]
    public string MetaType { get; set; }

    [JsonPropertyName("directoryAlias")]
    public string DirectoryAlias { get; set; }
}

