using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CanHarvest
{
    [JsonPropertyName("@resourcetype")]
    public string ResourceType { get; set; } = string.Empty;
}