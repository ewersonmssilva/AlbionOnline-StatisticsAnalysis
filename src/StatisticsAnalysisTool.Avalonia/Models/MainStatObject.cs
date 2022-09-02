using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models;

public class MainStatObject : ReactiveObject
{
    private CityFaction _cityFaction = CityFaction.Unknown;
    private double _value;
    private double _valuePerHour;
    private bool _isVisible;

    public CityFaction CityFaction
    {
        get => _cityFaction;
        set
        {
            _cityFaction = value;
            IsVisible = _cityFaction == CityFaction.Unknown;
            this.RaiseAndSetIfChanged(ref _cityFaction, value);
        }
    }

    public double Value
    {
        get => _value;
        set => this.RaiseAndSetIfChanged(ref _value, value);
    }

    public double ValuePerHour
    {
        get => _valuePerHour;
        set => this.RaiseAndSetIfChanged(ref _valuePerHour, value);
    }

    public bool IsVisible
    {
        get => _isVisible;
        set => this.RaiseAndSetIfChanged(ref _isVisible, value);
    }

    public static string TranslationTotalFactionPoints => LanguageController.Translation("TOTAL_FACTION_POINTS");
}