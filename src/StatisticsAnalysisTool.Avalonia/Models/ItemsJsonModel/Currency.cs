using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Currency
{
    [JsonPropertyName("@uniquename")]
    public string? UniqueName { get; set; }

    [JsonPropertyName("@amount")]
    public string? Amount { get; set; }
}