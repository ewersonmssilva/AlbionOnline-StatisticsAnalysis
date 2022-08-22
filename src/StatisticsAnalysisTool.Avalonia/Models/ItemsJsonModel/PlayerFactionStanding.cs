using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class PlayerFactionStanding
{
    [JsonPropertyName("@faction")]
    public string Faction { get; set; } = string.Empty;

    [JsonPropertyName("@minstanding")]
    public string MinStanding { get; set; } = string.Empty;
}