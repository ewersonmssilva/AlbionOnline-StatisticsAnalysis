using System;
using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.NetworkModel;

public class ValuePerHour
{
    public DateTime DateTime { get; set; }
    public CityFaction CityFaction { get; set; } = CityFaction.Unknown;
    public double Value { get; set; }
}