using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common.Converters;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class FurnitureItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@durability")]
    public string Durability { get; set; } = string.Empty;

    [JsonPropertyName("@durabilitylossperdayfactor")]
    public string Durabilitylossperdayfactor { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    [JsonPropertyName("@placeableindoors")]
    public string PlaceableIndoors { get; set; } = string.Empty;

    [JsonPropertyName("@placeableoutdoors")]
    public string PlaceableOutdoors { get; set; } = string.Empty;

    [JsonPropertyName("@placeableindungeons")]
    public string PlaceableInDungeons { get; set; } = string.Empty;

    [JsonPropertyName("@placeableinexpeditions")]
    public string PlaceableInExpeditions { get; set; } = string.Empty;

    [JsonPropertyName("@accessrightspreset")]
    public string AccessRightsPreset { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string UiCraftSoundStart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }
    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("repairkit")]
    public RepairKit RepairKit { get; set; } = new();

    [JsonPropertyName("@customizewithguildlogo")]
    public string CustomizeWithGuildLogo { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    [JsonPropertyName("@tile")]
    public string Tile { get; set; } = string.Empty;

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;

    [JsonPropertyName("@container")]
    public Container Container { get; set; } = new ();

    [JsonPropertyName("@showinmarketplace")]
    public bool ShowInMarketPlace { get; set; }

    [JsonPropertyName("@residencyslots")]
    public string ResidencySlots { get; set; } = string.Empty;

    [JsonPropertyName("@labourerfurnituretype")]
    public string LabourerFurnitureType { get; set; } = string.Empty;

    [JsonPropertyName("@labourersaffected")]
    public string LabourersAffected { get; set; } = string.Empty;

    [JsonPropertyName("@labourerhappiness")]
    public string LabourerHappiness { get; set; } = string.Empty;

    [JsonPropertyName("@labourersperfurnitureitem")]
    public string LabourersPerFurnitureItem { get; set; } = string.Empty;

    [JsonPropertyName("@placeableonlyonislands")]
    public string PlaceableOnlyOnIslands { get; set; } = string.Empty;

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;
}