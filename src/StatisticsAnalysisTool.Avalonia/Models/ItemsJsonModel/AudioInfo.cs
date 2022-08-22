using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class AudioInfo
{
    [JsonPropertyName("@name")]
    public string Name { get; set; } = string.Empty;
}