using System.Collections.Generic;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Common.Converters;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Mount : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@mountcategory")]
    public string Mountcategory { get; set; } = string.Empty;

    [JsonPropertyName("@maxqualitylevel")]
    public string Maxqualitylevel { get; set; } = string.Empty;

    [JsonPropertyName("@itempower")]
    public string Itempower { get; set; } = string.Empty;

    [JsonPropertyName("@abilitypower")]
    public string AbilityPower { get; set; } = string.Empty;

    [JsonPropertyName("@slottype")]
    public string SlotType { get; set; } = string.Empty;

    [JsonPropertyName("@shopcategory")]
    public string ShopCategory { get; set; } = string.Empty;

    [JsonPropertyName("@shopsubcategory1")]
    public string ShopSubCategory1 { get; set; } = string.Empty;

    [JsonPropertyName("@mountedbuff")]
    public string MountedBuff { get; set; } = string.Empty;

    [JsonPropertyName("@halfmountedbuff")]
    public string HalfMountedBuff { get; set; } = string.Empty;

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

    [JsonPropertyName("@durabilityloss_receivedattack_mounted")]
    public string DurabilityLossReceivedAttackMounted { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_receivedspell_mounted")]
    public string DurabilityLossReceivedSpellMounted { get; set; } = string.Empty;

    [JsonPropertyName("@durabilityloss_mounting")]
    public string DurabilityLossMounting { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtocraft")]
    public string UnlockedToCraft { get; set; } = string.Empty;

    [JsonPropertyName("@unlockedtoequip")]
    public string UnlockedToEquip { get; set; } = string.Empty;

    [JsonPropertyName("@mounttime")]
    public string MountTime { get; set; } = string.Empty;

    [JsonPropertyName("@dismounttime")]
    public string DismountTime { get; set; } = string.Empty;

    [JsonPropertyName("@mounthitpointsmax")]
    public string MountHitPointsMax { get; set; } = string.Empty;

    [JsonPropertyName("@mounthitpointsregeneration")]
    public string MountHitPointsRegeneration { get; set; } = string.Empty;

    //[JsonPropertyName("@prefabname")]
    //public string PrefabName { get; set; }

    //[JsonPropertyName("@prefabscaling")]
    //public string Prefabscaling { get; set; }

    //[JsonPropertyName("@despawneffect")]
    //public string DespawnEffect { get; set; }

    //[JsonPropertyName("@despawneffectscaling")]
    //public string DespawnEffectScaling { get; set; }

    [JsonPropertyName("@remountdistance")]
    public string RemountDistance { get; set; } = string.Empty;

    [JsonPropertyName("@halfmountrange")]
    public string HalfMountRange { get; set; } = string.Empty;

    [JsonPropertyName("@forceddismountcooldown")]
    public string ForcedDismountCooldown { get; set; } = string.Empty;

    [JsonPropertyName("@forceddismountspellcooldown")]
    public string ForcedDismountSpellCooldown { get; set; } = string.Empty;

    [JsonPropertyName("@fulldismountcooldown")]
    public string FullDismountCooldown { get; set; } = string.Empty;

    [JsonPropertyName("@remounttime")]
    public string RemountTime { get; set; } = string.Empty;

    //[JsonPropertyName("@uicraftsoundstart")]
    //public string Uicraftsoundstart { get; set; }

    //[JsonPropertyName("@uicraftsoundfinish")]
    //public string Uicraftsoundfinish { get; set; }

    [JsonPropertyName("@dismountbuff")]
    public string DismountBuff { get; set; } = string.Empty;

    [JsonPropertyName("@forceddismountbuff")]
    public string ForcedDismountBuff { get; set; } = string.Empty;

    [JsonPropertyName("@hostiledismountbuff")]
    public string Hostiledismountbuff { get; set; } = string.Empty;

    [JsonPropertyName("@showinmarketplace")]
    public bool ShowInMarketPlace { get; set; }

    [JsonPropertyName("@hidefromplayer")]
    public string HideFromPlayer { get; set; } = string.Empty;

    [JsonConverter(typeof(CraftingRequirementsToCraftingRequirementsList))]
    [JsonPropertyName("craftingrequirements")]
    public List<CraftingRequirements> CraftingRequirements { get; set; } = new();

    [JsonPropertyName("craftingspelllist")]
    public CraftingSpellList CraftingSpellList { get; set; } = new();
    //public SocketPreset SocketPreset { get; set; }
    //public AudioInfo AudioInfo { get; set; }
    //public AssetVfxPreset AssetVfxPreset { get; set; }
    //public FootStepVfxPreset FootStepVfxPreset { get; set; }

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    [JsonPropertyName("@nametagoffset")]
    public string NameTagOffset { get; set; } = string.Empty;

    [JsonPropertyName("@canuseingvg")]
    public string CanUseinGvg { get; set; } = string.Empty;
    [JsonPropertyName("mountspelllist")]
    public MountSpellList MountSpellList { get; set; } = new ();

    [JsonPropertyName("@enchantmentlevel")]
    public string EnchantmentLevel { get; set; } = string.Empty;

    //[JsonPropertyName("@vfxAddonKeyword")]
    //public string VfxAddonKeyword { get; set; }

    [JsonPropertyName("@canuseinfactionwarfare")]
    public string CanUseInFactionWarfare { get; set; } = string.Empty;

    [JsonPropertyName("@itemvalue")]
    public string ItemValue { get; set; } = string.Empty;
}