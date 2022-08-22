using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Common.Converters;
using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class EquipmentItem : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@maxqualitylevel")]
    public string MaxQualityLevel { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@slottype")]
    public string Slottype { get; set; } = string.Empty;

    [JsonPropertyName("@itempowerprogressiontype")]
    public string ItemPowerProgressionType { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string Uicraftsoundstart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }

    [JsonPropertyName("@skincount")]
    public string SkinCount { get; set; } = string.Empty;

    [JsonPropertyName("@tier")]
    public string Tier { get; set; } = string.Empty;

    [JsonPropertyName("@weight")]
    public string Weight { get; set; } = string.Empty;

    [JsonPropertyName("@activespellslots")]
    public string ActiveSpellSlots { get; set; } = string.Empty;

    [JsonPropertyName("@passivespellslots")]
    public string PassiveSpellSlots { get; set; } = string.Empty;

    [JsonPropertyName("@physicalarmor")]
    public string PhysicalArmor { get; set; } = string.Empty;

    [JsonPropertyName("@magicresistance")]
    public string MagicResistance { get; set; } = string.Empty;

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

    [JsonPropertyName("@offhandanimationtype")]
    public string OffHandAnimationType { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public bool UnlockedToCraft { get; set; }

    [JsonPropertyName("@unlockedtoequip")]
    public bool UnlockedToEquip { get; set; }

    [JsonPropertyName("@hitpointsmax")]
    public string HitPointsMax { get; set; } = string.Empty;

    [JsonPropertyName("@hitpointsregenerationbonus")]
    public string HitPointsRegenerationBonus { get; set; } = string.Empty;

    [JsonPropertyName("@energymax")]
    public string EnergyMax { get; set; } = string.Empty;

    [JsonPropertyName("@energyregenerationbonus")]
    public string EnergyRegenerationBonus { get; set; } = string.Empty;

    [JsonPropertyName("@crowdcontrolresistance")]
    public string CrowdControlResistance { get; set; } = string.Empty;

    [JsonPropertyName("@itempower")]
    public string ItemPower { get; set; } = string.Empty;

    [JsonPropertyName("@physicalattackdamagebonus")]
    public string PhysicalAttackDamageBonus { get; set; } = string.Empty;

    [JsonPropertyName("@magicattackdamagebonus")]
    public string MagicAttackDamageBonus { get; set; } = string.Empty;

    [JsonPropertyName("@physicalspelldamagebonus")]
    public string PhysicalSpellDamageBonus { get; set; } = string.Empty;

    [JsonPropertyName("@magicspelldamagebonus")]
    public string MagicSpellDamageBonus { get; set; } = string.Empty;

    [JsonPropertyName("@healbonus")]
    public string HealBonus { get; set; } = string.Empty;

    [JsonPropertyName("@bonusccdurationvsplayers")]
    public string BonusCcDurationVsPlayers { get; set; } = string.Empty;

    [JsonPropertyName("@bonusccdurationvsmobs")]
    public string BonusCcDurationVsMobs { get; set; } = string.Empty;

    [JsonPropertyName("@threatbonus")]
    public string ThreatBonus { get; set; } = string.Empty;

    [JsonPropertyName("@magiccooldownreduction")]
    public string MagicCooldownReduction { get; set; } = string.Empty;

    [JsonPropertyName("@bonusdefensevsplayers")]
    public string BonusDefenseVsPlayers { get; set; } = string.Empty;

    [JsonPropertyName("@bonusdefensevsmobs")]
    public string BonusDefenseVsMobs { get; set; } = string.Empty;

    [JsonPropertyName("@magiccasttimereduction")]
    public string MagicCastTimeReduction { get; set; } = string.Empty;

    [JsonPropertyName("@attackspeedbonus")]
    public string AttackSpeedBonus { get; set; } = string.Empty;

    [JsonPropertyName("@movespeedbonus")]
    public string MoveSpeedBonus { get; set; } = string.Empty;

    [JsonPropertyName("@healmodifier")]
    public string HealModifier { get; set; } = string.Empty;

    [JsonPropertyName("@canbeovercharged")]
    public bool CanBeOvercharged { get; set; }

    [JsonPropertyName("@showinmarketplace")]
    public bool ShowInMarketPlace { get; set; }

    [JsonPropertyName("@energycostreduction")]
    public string EnergyCostReduction { get; set; } = string.Empty;

    [JsonPropertyName("@masterymodifier")]
    public string MasteryModifier { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("@craftingcategory")]
    public string CraftingCategory { get; set; } = string.Empty;

    [JsonIgnore]
    public CraftingJournalType CraftingJournalType => CraftingController.GetCraftingJournalType(UniqueName, CraftingCategory);

    [JsonPropertyName("@combatspecachievement")]
    public string CombatSpecAchievement { get; set; } = string.Empty;
    //public SocketPreset SocketPreset { get; set; }
    [JsonPropertyName("enchantments")]
    public Enchantments Enchantments { get; set; } = new();

    [JsonPropertyName("@destinycraftfamefactor")]
    public string Destinycraftfamefactor { get; set; } = string.Empty;
    //public AssetVfxPreset AssetVfxPreset { get; set; }
}