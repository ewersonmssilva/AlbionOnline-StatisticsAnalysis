using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class GrownItem
{
    [JsonPropertyName("@uniquename")]
    public string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@growtime")]
    public string GrowTime { get; set; } = string.Empty;

    [JsonPropertyName("@fame")]
    public string Fame { get; set; } = string.Empty;

    [JsonPropertyName("offspring")] 
    public Offspring OffSpring { get; set; } = new();
}