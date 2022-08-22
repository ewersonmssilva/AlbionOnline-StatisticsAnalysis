using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class MountSkin : ItemJsonObject
{
    [JsonPropertyName("@uniquename")]
    public override string UniqueName { get; set; } = string.Empty;

    [JsonPropertyName("@uisprite")]
    public string UiSprite { get; set; } = string.Empty;

    //[JsonPropertyName("@prefabname")]
    //public string PrefabName { get; set; }

    //[JsonPropertyName("@prefabscaling")]
    //public string Prefabscaling { get; set; }

    //[JsonPropertyName("@despawneffect")]
    //public string DespawnEffect { get; set; }

    //[JsonPropertyName("@despawneffectscaling")]
    //public string DespawnEffectScaling { get; set; }
    //public SocketPreset SocketPreset { get; set; }
    //public AudioInfo AudioInfo { get; set; }
    //public FootStepVfxPreset FootStepVfxPreset { get; set; }
    //public AssetVfxPreset AssetVfxPreset { get; set; }
}