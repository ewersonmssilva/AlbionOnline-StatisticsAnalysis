using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;

namespace StatisticsAnalysisTool.Avalonia.Models;

public class LootedChests : ReactiveObject
{
    private int _outlandsCommonWeek;
    private int _outlandsCommonMonth;
    private int _outlandsUncommonWeek;
    private int _outlandsUncommonMonth;
    private int _outlandsEpicWeek;
    private int _outlandsEpicMonth;
    private int _outlandsLegendaryWeek;
    private int _outlandsLegendaryMonth;
    private int _randomGroupDungeonCommonWeek;
    private int _randomGroupDungeonCommonMonth;
    private int _randomGroupDungeonUncommonWeek;
    private int _randomGroupDungeonUncommonMonth;
    private int _randomGroupDungeonEpicWeek;
    private int _randomGroupDungeonEpicMonth;
    private int _randomGroupDungeonLegendaryWeek;
    private int _randomGroupDungeonLegendaryMonth;
    private int _avalonianRoadCommonWeek;
    private int _avalonianRoadCommonMonth;
    private int _avalonianRoadUncommonWeek;
    private int _avalonianRoadUncommonMonth;
    private int _avalonianRoadEpicWeek;
    private int _avalonianRoadEpicMonth;
    private int _avalonianRoadLegendaryWeek;
    private int _avalonianRoadLegendaryMonth;
    private int _hellGatesCommonWeek;
    private int _hellGatesCommonMonth;
    private int _hellGatesUncommonWeek;
    private int _hellGatesUncommonMonth;
    private int _hellGatesEpicWeek;
    private int _hellGatesEpicMonth;
    private int _hellGatesLegendaryWeek;
    private int _hellGatesLegendaryMonth;
    private int _outlandsCommonYear;
    private int _outlandsUncommonYear;
    private int _outlandsEpicYear;
    private int _outlandsLegendaryYear;
    private int _randomGroupDungeonCommonYear;
    private int _randomGroupDungeonUncommonYear;
    private int _randomGroupDungeonEpicYear;
    private int _randomGroupDungeonLegendaryYear;
    private int _avalonianRoadCommonYear;
    private int _avalonianRoadUncommonYear;
    private int _avalonianRoadEpicYear;
    private int _avalonianRoadLegendaryYear;
    private int _hellGatesCommonYear;
    private int _hellGatesUncommonYear;
    private int _hellGatesEpicYear;
    private int _hellGatesLegendaryYear;
    private int _randomSoloDungeonCommonWeek;
    private int _randomSoloDungeonCommonMonth;
    private int _randomSoloDungeonCommonYear;
    private int _randomSoloDungeonUncommonWeek;
    private int _randomSoloDungeonUncommonMonth;
    private int _randomSoloDungeonUncommonYear;
    private int _randomSoloDungeonEpicWeek;
    private int _randomSoloDungeonEpicMonth;
    private int _randomSoloDungeonEpicYear;
    private int _randomSoloDungeonLegendaryWeek;
    private int _randomSoloDungeonLegendaryMonth;
    private int _randomSoloDungeonLegendaryYear;

    #region OpenWorld bindings

    public int OpenWorldCommonWeek
    {
        get => _outlandsCommonWeek;
        set => this.RaiseAndSetIfChanged(ref _outlandsCommonWeek, value);
    }

    public int OpenWorldCommonMonth
    {
        get => _outlandsCommonMonth;
        set => this.RaiseAndSetIfChanged(ref _outlandsCommonMonth, value);
    }

    public int OpenWorldCommonYear
    {
        get => _outlandsCommonYear;
        set => this.RaiseAndSetIfChanged(ref _outlandsCommonYear, value);
    }

    public int OpenWorldUncommonWeek
    {
        get => _outlandsUncommonWeek;
        set => this.RaiseAndSetIfChanged(ref _outlandsUncommonWeek, value);
    }

    public int OpenWorldUncommonMonth
    {
        get => _outlandsUncommonMonth;
        set => this.RaiseAndSetIfChanged(ref _outlandsUncommonMonth, value);
    }

    public int OpenWorldUncommonYear
    {
        get => _outlandsUncommonYear;
        set => this.RaiseAndSetIfChanged(ref _outlandsUncommonYear, value);
    }

    public int OpenWorldEpicWeek
    {
        get => _outlandsEpicWeek;
        set => this.RaiseAndSetIfChanged(ref _outlandsEpicWeek, value);
    }

    public int OpenWorldEpicMonth
    {
        get => _outlandsEpicMonth;
        set => this.RaiseAndSetIfChanged(ref _outlandsEpicMonth, value);
    }

    public int OpenWorldEpicYear
    {
        get => _outlandsEpicYear;
        set => this.RaiseAndSetIfChanged(ref _outlandsEpicYear, value);
    }

    public int OpenWorldLegendaryWeek
    {
        get => _outlandsLegendaryWeek;
        set => this.RaiseAndSetIfChanged(ref _outlandsLegendaryWeek, value);
    }

    public int OpenWorldLegendaryMonth
    {
        get => _outlandsLegendaryMonth;
        set => this.RaiseAndSetIfChanged(ref _outlandsLegendaryMonth, value);
    }

    public int OpenWorldLegendaryYear
    {
        get => _outlandsLegendaryYear;
        set => this.RaiseAndSetIfChanged(ref _outlandsLegendaryYear, value);
    }

    #endregion

    #region Random group dungeon bindings

    public int RandomGroupDungeonCommonWeek
    {
        get => _randomGroupDungeonCommonWeek;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonCommonWeek, value);
    }

    public int RandomGroupDungeonCommonMonth
    {
        get => _randomGroupDungeonCommonMonth;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonCommonMonth, value);
    }

    public int RandomGroupDungeonCommonYear
    {
        get => _randomGroupDungeonCommonYear;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonCommonYear, value);
    }

    public int RandomGroupDungeonUncommonWeek
    {
        get => _randomGroupDungeonUncommonWeek;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonUncommonWeek, value);
    }

    public int RandomGroupDungeonUncommonMonth
    {
        get => _randomGroupDungeonUncommonMonth;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonUncommonMonth, value);
    }

    public int RandomGroupDungeonUncommonYear
    {
        get => _randomGroupDungeonUncommonYear;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonUncommonYear, value);
    }

    public int RandomGroupDungeonEpicWeek
    {
        get => _randomGroupDungeonEpicWeek;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonEpicWeek, value);
    }

    public int RandomGroupDungeonEpicMonth
    {
        get => _randomGroupDungeonEpicMonth;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonEpicMonth, value);
    }

    public int RandomGroupDungeonEpicYear
    {
        get => _randomGroupDungeonEpicYear;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonEpicYear, value);
    }

    public int RandomGroupDungeonLegendaryWeek
    {
        get => _randomGroupDungeonLegendaryWeek;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonLegendaryWeek, value);
    }

    public int RandomGroupDungeonLegendaryMonth
    {
        get => _randomGroupDungeonLegendaryMonth;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonLegendaryMonth, value);
    }

    public int RandomGroupDungeonLegendaryYear
    {
        get => _randomGroupDungeonLegendaryYear;
        set => this.RaiseAndSetIfChanged(ref _randomGroupDungeonLegendaryYear, value);
    }

    #endregion

    #region Random solo dungeon bindings

    public int RandomSoloDungeonCommonWeek
    {
        get => _randomSoloDungeonCommonWeek;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonCommonWeek, value);
    }

    public int RandomSoloDungeonCommonMonth
    {
        get => _randomSoloDungeonCommonMonth;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonCommonMonth, value);
    }

    public int RandomSoloDungeonCommonYear
    {
        get => _randomSoloDungeonCommonYear;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonCommonYear, value);
    }

    public int RandomSoloDungeonUncommonWeek
    {
        get => _randomSoloDungeonUncommonWeek;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonUncommonWeek, value);
    }

    public int RandomSoloDungeonUncommonMonth
    {
        get => _randomSoloDungeonUncommonMonth;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonUncommonMonth, value);
    }

    public int RandomSoloDungeonUncommonYear
    {
        get => _randomSoloDungeonUncommonYear;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonUncommonYear, value);
    }

    public int RandomSoloDungeonEpicWeek
    {
        get => _randomSoloDungeonEpicWeek;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonEpicWeek, value);
    }

    public int RandomSoloDungeonEpicMonth
    {
        get => _randomSoloDungeonEpicMonth;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonEpicMonth, value);
    }

    public int RandomSoloDungeonEpicYear
    {
        get => _randomSoloDungeonEpicYear;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonEpicYear, value);
    }

    public int RandomSoloDungeonLegendaryWeek
    {
        get => _randomSoloDungeonLegendaryWeek;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonLegendaryWeek, value);
    }

    public int RandomSoloDungeonLegendaryMonth
    {
        get => _randomSoloDungeonLegendaryMonth;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonLegendaryMonth, value);
    }

    public int RandomSoloDungeonLegendaryYear
    {
        get => _randomSoloDungeonLegendaryYear;
        set => this.RaiseAndSetIfChanged(ref _randomSoloDungeonLegendaryYear, value);
    }

    #endregion

    #region Avalonian Road bindings

    public int AvalonianRoadCommonWeek
    {
        get => _avalonianRoadCommonWeek;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadCommonWeek, value);
    }

    public int AvalonianRoadCommonMonth
    {
        get => _avalonianRoadCommonMonth;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadCommonMonth, value);
    }

    public int AvalonianRoadCommonYear
    {
        get => _avalonianRoadCommonYear;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadCommonYear, value);
    }

    public int AvalonianRoadUncommonWeek
    {
        get => _avalonianRoadUncommonWeek;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadUncommonWeek, value);
    }

    public int AvalonianRoadUncommonMonth
    {
        get => _avalonianRoadUncommonMonth;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadUncommonMonth, value);
    }

    public int AvalonianRoadUncommonYear
    {
        get => _avalonianRoadUncommonYear;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadUncommonYear, value);
    }

    public int AvalonianRoadEpicWeek
    {
        get => _avalonianRoadEpicWeek;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadEpicWeek, value);
    }

    public int AvalonianRoadEpicMonth
    {
        get => _avalonianRoadEpicMonth;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadEpicMonth, value);
    }

    public int AvalonianRoadEpicYear
    {
        get => _avalonianRoadEpicYear;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadEpicYear, value);
    }

    public int AvalonianRoadLegendaryWeek
    {
        get => _avalonianRoadLegendaryWeek;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadLegendaryWeek, value);
    }

    public int AvalonianRoadLegendaryMonth
    {
        get => _avalonianRoadLegendaryMonth;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadLegendaryMonth, value);
    }

    public int AvalonianRoadLegendaryYear
    {
        get => _avalonianRoadLegendaryYear;
        set => this.RaiseAndSetIfChanged(ref _avalonianRoadLegendaryYear, value);
    }

    #endregion

    #region Hellgate bindings

    public int HellGateCommonWeek
    {
        get => _hellGatesCommonWeek;
        set => this.RaiseAndSetIfChanged(ref _hellGatesCommonWeek, value);
    }

    public int HellGateCommonMonth
    {
        get => _hellGatesCommonMonth;
        set => this.RaiseAndSetIfChanged(ref _hellGatesCommonMonth, value);
    }

    public int HellGateCommonYear
    {
        get => _hellGatesCommonYear;
        set => this.RaiseAndSetIfChanged(ref _hellGatesCommonYear, value);
    }

    public int HellGateUncommonWeek
    {
        get => _hellGatesUncommonWeek;
        set => this.RaiseAndSetIfChanged(ref _hellGatesUncommonWeek, value);
    }

    public int HellGateUncommonMonth
    {
        get => _hellGatesUncommonMonth;
        set => this.RaiseAndSetIfChanged(ref _hellGatesUncommonMonth, value);
    }

    public int HellGateUncommonYear
    {
        get => _hellGatesUncommonYear;
        set => this.RaiseAndSetIfChanged(ref _hellGatesUncommonYear, value);
    }

    public int HellGateEpicWeek
    {
        get => _hellGatesEpicWeek;
        set => this.RaiseAndSetIfChanged(ref _hellGatesEpicWeek, value);
    }

    public int HellGateEpicMonth
    {
        get => _hellGatesEpicMonth;
        set => this.RaiseAndSetIfChanged(ref _hellGatesEpicMonth, value);
    }

    public int HellGateEpicYear
    {
        get => _hellGatesEpicYear;
        set => this.RaiseAndSetIfChanged(ref _hellGatesEpicYear, value);
    }

    public int HellGateLegendaryWeek
    {
        get => _hellGatesLegendaryWeek;
        set => this.RaiseAndSetIfChanged(ref _hellGatesLegendaryWeek, value);
    }

    public int HellGateLegendaryMonth
    {
        get => _hellGatesLegendaryMonth;
        set => this.RaiseAndSetIfChanged(ref _hellGatesLegendaryMonth, value);
    }

    public int HellGateLegendaryYear
    {
        get => _hellGatesLegendaryYear;
        set => this.RaiseAndSetIfChanged(ref _hellGatesLegendaryYear, value);
    }

    #endregion

    public static string TranslationLootedChests => LanguageController.Translation("LOOTED_CHESTS");
    public static string TranslationOpenWorld => LanguageController.Translation("OPEN_WORLD");
    public static string TranslationStaticDungeons => LanguageController.Translation("STATIC_DUNGEONS");
    public static string TranslationAvalonianRoads => LanguageController.Translation("AVALONIAN_ROADS");
    public static string TranslationRandomSoloDungeons => LanguageController.Translation("RANDOM_SOLO_DUNGEONS");
    public static string TranslationRandomGroupDungeons => LanguageController.Translation("RANDOM_GROUP_DUNGEONS");
    public static string TranslationHellGates => LanguageController.Translation("HELLGATES");
    public static string TranslationLast7Days => LanguageController.Translation("LAST_7_DAYS");
    public static string TranslationLast30Days => LanguageController.Translation("LAST_30_DAYS");
    public static string TranslationLast365Days => LanguageController.Translation("LAST_365_DAYS");
}