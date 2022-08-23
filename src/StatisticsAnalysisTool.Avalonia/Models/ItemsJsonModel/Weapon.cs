using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Common.Converters;
using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Weapon : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    //[JsonPropertyName("@mesh")]
    //public string Mesh { get; set; }

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@maxqualitylevel")]
    public string MaxQualityLevel { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@slottype")]
    public string SlotType { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@attacktype")]
    public string AttackType { get; set; } = string.Empty;

    [JsonPropertyName("@attackdamage")]
    public string AttackDamage { get; set; } = string.Empty;

    [JsonPropertyName("@attackspeed")]
    public string AttackSpeed { get; set; } = string.Empty;

    [JsonPropertyName("@attackrange")]
    public string AttackRange { get; set; } = string.Empty;

    [JsonPropertyName("@twohanded")]
    public bool TwoHanded { get; set; }

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@activespellslots")]
    public string ActiveSpellSlots { get; set; } = string.Empty;

    [JsonPropertyName("@passivespellslots")]
    public string PassiveSpellSlots { get; set; } = string.Empty;

    [JsonPropertyName("@durability")]
    public string Durability { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_attack")]
    public string DurabilityLossAttack { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_spelluse")]
    public string DurabilityLossSpellUse { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_receivedattack")]
    public string DurabilityLossReceivedAttack { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_receivedspell")]
    public string DurabilityLossReceivedSpell { get; set; } = string.Empty;

    //[JsonPropertyName("@mainhandanimationtype")]
    //public string Mainhandanimationtype { get; set; }

    [JsonPropertyName("@unlockedtocraft")]
    public bool UnlockedToCraft { get; set; }

    [JsonPropertyName("@unlockedtoequip")]
    public bool UnlockedToEquip { get; set; }

    [JsonPropertyName("@itempower")]
    public string ItemPower { get; set; } = string.Empty;

    [JsonPropertyName("@unequipincombat")]
    public bool UnEquipInCombat { get; set; }

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string Uicraftsoundstart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }

    [JsonPropertyName("@canbeovercharged")]
    public bool CanBeOvercharged { get; set; }

    [JsonPropertyName("@showinmarketplace")]
    public bool ShowInMarketPlace { get; set; }

    [JsonPropertyName("canharvest")]
    public CanHarvest CanHarvest { get; set; } = new();

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements>? CraftingRequirements { get; set; }

    //public AudioInfo AudioInfo { get; set; }
    //public SocketPreset SocketPreset { get; set; }

    [JsonPropertyName("@craftingcategory")]
    public string CraftingCategory { get; set; } = string.Empty;

    [JsonIgnore] 
    public CraftingJournalType CraftingJournalType => CraftingController.GetCraftingJournalType(UniqueName, CraftingCategory);

    [JsonPropertyName("@descriptionlocatag")]
    public string DescriptionLocaTag { get; set; } = string.Empty;

    [JsonPropertyName("craftingspelllist")]
    public CraftingSpellList CraftingSpellList { get; set; } = new();
}