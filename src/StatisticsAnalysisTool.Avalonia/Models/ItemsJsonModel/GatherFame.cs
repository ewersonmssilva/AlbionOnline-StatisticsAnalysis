using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class GatherFame
{
    [JsonPropertyName("@mintier")]
    public string Mintier { get; set; } = string.Empty;

    [JsonPropertyName("@value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("validitem")] 
    public List<ValidItem> ValidItem { get; set; } = new();
}