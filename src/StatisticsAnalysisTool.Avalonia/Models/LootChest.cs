using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models
{
    public class LootChest
    {
        [JsonPropertyName("@uniquename")]
        public string? UniqueName { get; set; }

        [JsonPropertyName("@faction")]
        public string? Faction { get; set; }
    }
}