using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class LootList
{
    [JsonPropertyName("loot")]
    public object Loot { get; set; } = new();
}