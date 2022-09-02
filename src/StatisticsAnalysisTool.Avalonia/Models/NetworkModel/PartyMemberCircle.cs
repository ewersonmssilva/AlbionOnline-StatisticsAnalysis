using ReactiveUI;
using System;

namespace StatisticsAnalysisTool.Avalonia.Models.NetworkModel;

public class PartyMemberCircle : ReactiveObject
{
    public Guid UserGuid { get; set; }

    private string? _name;
    private string? _weaponCategoryId;

    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string? WeaponCategoryId
    {
        get => _weaponCategoryId;
        set => this.RaiseAndSetIfChanged(ref _weaponCategoryId, value);
    }
}