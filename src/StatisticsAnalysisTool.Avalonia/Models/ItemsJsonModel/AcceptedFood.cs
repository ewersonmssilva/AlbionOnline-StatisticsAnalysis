using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class AcceptedFood
{
    [JsonPropertyName("@foodcategory")]
    public string? FoodCategory { get; set; }
}