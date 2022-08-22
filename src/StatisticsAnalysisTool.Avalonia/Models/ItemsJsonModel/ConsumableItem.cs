using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common.Converters;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class ConsumableItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@fishingfame")]
    public string FishingFame { get; set; } = string.Empty;

    [JsonPropertyName("@fishingminigamesetting")]
    public string FishingMiniGameSetting { get; set; } = string.Empty;

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@nutrition")]
    public string Nutrition { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@slottype")]
    public string SlotType { get; set; } = string.Empty;

    [JsonPropertyName("@consumespell")]
    public string ConsumeSpell { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@resourcetype")]
    public string ResourceType { get; set; } = string.Empty;

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

    [JsonPropertyName("@unlockedtoequip")]
    public string UnlockedToEquip { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string UiCraftSoundStart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string UiCraftSoundFinish { get; set; }

    [JsonPropertyName("@craftingcategory")]
    public string CraftingCategory { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("enchantments")]
    public Enchantments Enchantments { get; set; } = new();
}