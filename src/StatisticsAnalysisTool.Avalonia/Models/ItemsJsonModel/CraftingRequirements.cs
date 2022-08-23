using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CraftingRequirements
{
    [JsonPropertyName("@silver")]
    public string Silver { get; set; } = string.Empty;

    [JsonPropertyName("@time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("@craftingfocus")]
    public string CraftingFocus { get; set; } = string.Empty;

    [JsonPropertyName("craftresource")]
    public List<CraftResource>? CraftResource { get; set; }

    [JsonPropertyName("@swaptransaction")]
    public string SwapTransaction { get; set; } = string.Empty;

    [JsonPropertyName("playerfactionstanding")]
    public PlayerFactionStanding PlayerFactionStanding { get; set; } = new();

    [JsonPropertyName("currency")]
    public Currency Currency { get; set; } = new();

    [JsonPropertyName("@amountcrafted")]
    public string AmountCrafted { get; set; } = string.Empty;

    [JsonPropertyName("@forcesinglecraft")]
    public string ForceSingleCraft { get; set; } = string.Empty;

    [JsonPropertyName("@compensategold")]
    public string CompensateGold { get; set; } = string.Empty;
}