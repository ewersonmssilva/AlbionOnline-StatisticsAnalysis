using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Items
{
    [JsonPropertyName("shopcategories")]
    public ShopCategories ShopCategories { get; set; } = new();
    [JsonPropertyName("hideoutitem")]
    public HideoutItem HideoutItem { get; set; } = new();
    [JsonPropertyName("farmableitem")]
    public List<FarmableItem> FarmableItem { get; set; } = new();
    [JsonPropertyName("simpleitem")]
    public List<SimpleItem> SimpleItem { get; set; } = new();
    [JsonPropertyName("consumableitem")]
    public List<ConsumableItem> ConsumableItem { get; set; } = new();
    [JsonPropertyName("consumablefrominventoryitem")]
    public List<ConsumableFromInventoryItem> ConsumableFromInventoryItem { get; set; } = new();
    [JsonPropertyName("equipmentitem")]
    public List<EquipmentItem> EquipmentItem { get; set; } = new();
    [JsonPropertyName("weapon")]
    public List<Weapon> Weapon { get; set; } = new();
    [JsonPropertyName("mount")]
    public List<Mount> Mount { get; set; } = new();
    [JsonPropertyName("furnitureitem")]
    public List<FurnitureItem> FurnitureItem { get; set; } = new();
    [JsonPropertyName("journalitem")]
    public List<JournalItem> JournalItem { get; set; } = new();
    [JsonPropertyName("labourercontract")]
    public List<LabourerContract> LabourerContract { get; set; } = new();
    [JsonPropertyName("mountskin")]
    public List<MountSkin> MountSkin { get; set; } = new();
    [JsonPropertyName("crystalleagueitem")]
    public List<CrystalLeagueItem> CrystalLeagueItem { get; set; } = new();
}