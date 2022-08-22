using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Enchantments
{
    [JsonPropertyName("enchantment")]
    public object Enchantment { get; set; } = string.Empty;
}