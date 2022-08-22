using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class UpgradeRequirements
{
    [JsonPropertyName("upgraderesource")] 
    public UpgradeResource UpgradeResource { get; set; } = new();
}