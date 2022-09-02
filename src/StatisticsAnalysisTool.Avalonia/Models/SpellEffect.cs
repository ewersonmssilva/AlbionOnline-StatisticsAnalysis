using System;

namespace StatisticsAnalysisTool.Avalonia.Models;

public class SpellEffect
{
    public SpellEffect()
    {
        TimeStamp = DateTime.UtcNow;
    }

    public DateTime TimeStamp { get; }
    public long CauserId { get; set; }
    public int SpellIndex { get; set; }
}