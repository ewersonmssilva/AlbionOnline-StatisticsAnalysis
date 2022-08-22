using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class RepairKit
{
    [JsonPropertyName("@repaircostfactor")]
    public string RepairCostFactor { get; set; } = string.Empty;

    [JsonPropertyName("@maxtier")]
    public string MaxTier { get; set; } = string.Empty;
}