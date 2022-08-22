using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class FameFillingMissions
{
    [JsonPropertyName("gatherfame")] 
    public GatherFame GatherFame { get; set; } = new();
    [JsonPropertyName("craftitemfame")] 
    public CraftItemFame CraftItemFame { get; set; } = new();
}