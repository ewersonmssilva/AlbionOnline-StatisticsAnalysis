using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Container
{
    [JsonPropertyName("@capacity")]
    public string Capacity { get; set; } = string.Empty;

    [JsonPropertyName("@weightlimit")]
    public string WeightLimit { get; set; } = string.Empty;
}