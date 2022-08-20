using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CraftResource
{
    [JsonPropertyName("@uniquename")]
    public string? UniqueName { get; set; }

    [JsonPropertyName("@count")]
    public int Count { get; set; }

    [JsonPropertyName("@maxreturnamount")]
    public string? MaxReturnAmount { get; set; }

    [JsonPropertyName("@enchantmentlevel")]
    public string? EnchantmentLevel { get; set; }
}