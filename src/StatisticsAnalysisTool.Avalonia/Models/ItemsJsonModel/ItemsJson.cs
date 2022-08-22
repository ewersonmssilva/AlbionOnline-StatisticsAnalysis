using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class ItemsJson
{
    [JsonPropertyName("items")]
    public Items Items { get; set; } = new();
}