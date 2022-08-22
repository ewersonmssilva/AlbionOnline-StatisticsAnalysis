using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Offspring
{
    [JsonPropertyName("@chance")]
    public string Chance { get; set; } = string.Empty;

    [JsonPropertyName("@amount")]
    public string Amount { get; set; } = string.Empty;
}