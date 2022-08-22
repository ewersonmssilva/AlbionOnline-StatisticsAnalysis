using StatisticsAnalysisTool.Avalonia.Common.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class FarmableItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@placefame")]
    public string PlaceFame { get; set; } = string.Empty;

    [JsonPropertyName("@pickupable")]
    public bool Pickupable { get; set; }

    [JsonPropertyName("@destroyable")]
    public bool Destroyable { get; set; }

    [JsonPropertyName("@unlockedtoplace")]
    public bool UnlockedToPlace { get; set; }

    [JsonPropertyName("@maxstacksize")]
    public string MaxStackSize { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public bool UnlockedToCraft { get; set; }

    [JsonPropertyName("@animationid")]
    public string AnimationId { get; set; } = string.Empty;

    [JsonPropertyName("@activefarmfocuscost")]
    public string ActiveFarmFocusCost { get; set; } = string.Empty;

    [JsonPropertyName("@activefarmmaxcycles")]
    public string ActiveFarmMaxCycles { get; set; } = string.Empty;

    [JsonPropertyName("@activefarmactiondurationseconds")]
    public string ActiveFarmActionDurationSeconds { get; set; } = string.Empty;

    [JsonPropertyName("@activefarmcyclelengthseconds")]
    public string ActiveFarmCycleLengthSeconds { get; set; } = string.Empty;

    [JsonPropertyName("@activefarmbonus")]
    public string ActiveFarmBonus { get; set; } = string.Empty;

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();
    //public AudioInfo AudioInfo { get; set; }
    [JsonPropertyName("harvest")]
    public Harvest Harvest { get; set; } = new();

    [JsonPropertyName("@prefabname")]
    public string PrefabName { get; set; } = string.Empty;

    [JsonPropertyName("@prefabscale")]
    public string PrefabScale { get; set; } = string.Empty;

    [JsonPropertyName("@resourcevalue")]
    public string ResourceValue { get; set; } = string.Empty;

    [JsonPropertyName("grownitem")]
    public GrownItem GrownItem { get; set; } = new();

    [JsonPropertyName("consumption")]
    public Consumption Consumption { get; set; } = new();

    [JsonPropertyName("@tile")]
    public string Tile { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@showinmarketplace")]
    public bool ShowInMarketPlace { get; set; }
}