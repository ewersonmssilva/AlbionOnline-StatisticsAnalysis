using StatisticsAnalysisTool.Avalonia.Common.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class HideoutItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@mindistance")]
    public string MinDistance { get; set; } = string.Empty;

    [JsonPropertyName("@mindistanceintunnel")]
    public string MinDistanceinTunnel { get; set; } = string.Empty;

    [JsonPropertyName("@placementduration")]
    public string Placementduration { get; set; } = string.Empty;

    [JsonPropertyName("@primetimedurationminutes")]
    public string Primetimedurationminutes { get; set; } = string.Empty;

    [JsonPropertyName("@maxstacksize")]
    public string Maxstacksize { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string Unlockedtocraft { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string UiCraftSoundStart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();
}