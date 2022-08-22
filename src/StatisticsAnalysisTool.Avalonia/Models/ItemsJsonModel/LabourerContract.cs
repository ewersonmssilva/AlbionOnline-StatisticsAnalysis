using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class LabourerContract : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;
}