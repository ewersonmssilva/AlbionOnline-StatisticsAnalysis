using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CraftResource
{
    [JsonPropertyName("@uniquename")]
    public string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@count")]
    public int Count { get; set; }

    [JsonPropertyName("@maxreturnamount")]
    public string MaxReturnAmount { get; set; } = string.Empty;

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;
}