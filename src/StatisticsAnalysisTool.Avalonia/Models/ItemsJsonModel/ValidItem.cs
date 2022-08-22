using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class ValidItem
{
    [JsonPropertyName("@id")] 
    public string Id { get; set; } = string.Empty;
}