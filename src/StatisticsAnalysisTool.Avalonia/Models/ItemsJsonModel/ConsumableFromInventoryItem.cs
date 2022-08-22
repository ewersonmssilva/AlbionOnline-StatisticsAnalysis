using StatisticsAnalysisTool.Avalonia.Common.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class ConsumableFromInventoryItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@tradable")]
    public string Tradable { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@consumespell")]
    public string ConsumeSpell { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@dummyitempower")]
    public string DummyItemPower { get; set; } = string.Empty;

    [JsonPropertyName("@maxstacksize")]
    public string MaxStackSize { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string Uicraftsoundstart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }

    //[JsonPropertyName("@uispriteoverlay1")]
    //public string Uispriteoverlay1 { get; set; }

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("@allowfullstackusage")]
    public string AllowFullStackUsage { get; set; } = string.Empty;

    [JsonPropertyName("@logconsumption")]
    public string LogConsumption { get; set; } = string.Empty;

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("@craftingcategory")]
    public string CraftingCategory { get; set; } = string.Empty;
}