using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common.Converters;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class JournalItem : ItemJsonObject
{
    [JsonPropertyName("@salvageable")]
    public string Salvageable { get; set; } = string.Empty;

    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@maxfame")]
    public string MaxFame { get; set; } = string.Empty;

    [JsonPropertyName("@baselootamount")]
    public string BaseLootAmount { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    [JsonPropertyName("@fasttravelfactor")]
    public string FastTravelFactor { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("famefillingmissions")]
    public FameFillingMissions FameFillingMissions { get; set; } = new();

    [JsonPropertyName("lootlist")] 
    public LootList LootList { get; set; } = new();
}