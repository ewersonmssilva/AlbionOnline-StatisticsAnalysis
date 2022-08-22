using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common.Converters;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class SimpleItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@maxstacksize")]
    public string MaxStackSize { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public bool UnlockedToCraft { get; set; }

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonPropertyName("@nutrition")]
    public string Nutrition { get; set; } = string.Empty;

    [JsonPropertyName("@foodcategory")]
    public string FoodCategory { get; set; } = string.Empty;

    [JsonPropertyName("@resourcetype")]
    public string ResourceType { get; set; } = string.Empty;

    [JsonPropertyName("@famevalue")]
    public string FameValue { get; set; } = string.Empty;

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    [JsonPropertyName("@fishingfame")]
    public string FishingFame { get; set; } = string.Empty;

    [JsonPropertyName("@fishingminigamesetting")]
    public string FishingMiniGameSetting { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("@fasttravelfactor")]
    public string FastTravelFactor { get; set; } = string.Empty;
}