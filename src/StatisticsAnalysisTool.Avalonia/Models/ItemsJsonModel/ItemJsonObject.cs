using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public abstract class ItemJsonObject
{
    public virtual string UniqueName { get; set; } = string.Empty;
    public virtual ItemType ItemType { get; set; }
}