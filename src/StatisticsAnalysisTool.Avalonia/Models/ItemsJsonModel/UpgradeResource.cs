using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class UpgradeResource
{
    [JsonPropertyName("@uniquename")]
    public string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@count")]
    public string Count { get; set; } = string.Empty;
}