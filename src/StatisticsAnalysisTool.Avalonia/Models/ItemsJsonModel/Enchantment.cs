using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Enchantment
{
    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@dummyitempower")]
    public string DummyItemPower { get; set; } = string.Empty;

    [JsonPropertyName("@consumespell")]
    public string ConsumeSpell { get; set; } = string.Empty;
    [JsonPropertyName("craftingrequirements")]
    public CraftingRequirements CraftingRequirements { get; set; } = new();
    [JsonPropertyName("upgraderequirements")]
    public UpgradeRequirements UpgradeRequirements { get; set; } = new();

    [JsonPropertyName("@itempower")]
    public string ItemPower { get; set; } = string.Empty;

    [JsonPropertyName("@durability")]
    public string Durability { get; set; } = string.Empty;
}