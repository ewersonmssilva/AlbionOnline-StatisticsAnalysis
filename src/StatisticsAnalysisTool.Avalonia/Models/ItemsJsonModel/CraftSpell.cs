using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CraftSpell
{
    [JsonPropertyName("@uniquename")]
    public string UniqueName { get; set; } = string.Empty;
}