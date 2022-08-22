using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class ShopCategory
{
    [JsonPropertyName("@id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("@value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("shopsubcategory")] 
    public object ShopSubCategory { get; set; } = new ();
}