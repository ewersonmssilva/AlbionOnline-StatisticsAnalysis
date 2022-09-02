using System;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models;

public class GoldResponseModel
{
    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
}