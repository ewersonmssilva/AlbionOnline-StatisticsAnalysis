using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CraftingSpellList
{
    [JsonPropertyName("craftspell")] 
    public object CraftSpell { get; set; } = new();
}