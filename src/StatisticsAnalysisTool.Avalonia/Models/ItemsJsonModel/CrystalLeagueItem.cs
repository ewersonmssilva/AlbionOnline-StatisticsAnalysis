using StatisticsAnalysisTool.Avalonia.Common.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class CrystalLeagueItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    [JsonPropertyName("@resourcetype")]
    public string ResourceType { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@maxstacksize")]
    public string MaxStackSize { get; set; } = string.Empty;

    [JsonPropertyName("@namelocatag")]
    public string NameLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("@descvariable0")]
    public string DescVariable0 { get; set; } = string.Empty;

    [JsonPropertyName("@salvageable")]
    public string Salvageable { get; set; } = string.Empty;

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonPropertyName("@tradable")]
    public string Tradable { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    [JsonPropertyName("@canbestoredinbattlevault")]
    public string CanBeStoredInBattleVault { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    //[JsonPropertyName("@uispriteoverlay1")]
    //public string Uispriteoverlay1 { get; set; }
}