using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Harvest
{
    [JsonPropertyName("@growtime")]
    public string GrowTime { get; set; } = string.Empty;

    [JsonPropertyName("@lootlist")]
    public string LootList { get; set; } = string.Empty;

    [JsonPropertyName("@lootchance")]
    public string LootChance { get; set; } = string.Empty;

    [JsonPropertyName("@fame")]
    public string Fame { get; set; } = string.Empty;

    [JsonPropertyName("seed")] 
    public Seed Seed { get; set; } = new();
}