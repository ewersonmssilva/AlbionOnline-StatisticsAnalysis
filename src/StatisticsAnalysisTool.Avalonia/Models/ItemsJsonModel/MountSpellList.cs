using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class MountSpellList
{
    [JsonPropertyName("mountspell")] 
    public object MountSpell { get; set; } = new();
}