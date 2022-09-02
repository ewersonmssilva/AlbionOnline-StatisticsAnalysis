using Avalonia.Threading;
using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using StatisticsAnalysisTool.Avalonia.GameData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;
using StatisticsAnalysisTool.Avalonia.Models.NetworkModel;

namespace StatisticsAnalysisTool.Avalonia.Network.Notification;

public class DungeonNotificationFragment : LineFragment
{
    private bool _diedInDungeon;
    private string? _diedName;
    private string? _killedBy;
    private ObservableCollection<DungeonEventObjectFragment> _dungeonChests = new();
    private DateTime _enterDungeonFirstTime;
    private Faction _faction = Faction.Unknown;
    private double _fame;
    private double _famePerHour;
    private bool _isBestFame;
    private bool _isBestFamePerHour;
    private bool _isBestReSpec;
    private bool _isBestReSpecPerHour;
    private bool _isBestSilver;
    private bool _isBestSilverPerHour;
    private bool _isBestTime;
    private string _mainMapIndex;
    private string _mainMapName;
    private List<Guid> _guidList;
    private DungeonMode _mode = DungeonMode.Unknown;
    private double _reSpec;
    private double _reSpecPerHour;
    private string _runTimeString;
    private double _silver;
    private double _silverPerHour;
    private DungeonStatus _status;
    private int _totalRunTimeInSeconds;
    private int _dungeonNumber;
    private double _factionCoinsPerHour;
    private double _factionFlagsPerHour;
    private double _factionFlags;
    private double _factionCoins;
    private bool _isFactionWarfareVisible;
    private bool _isBestFactionCoinsPerHour;
    private bool _isBestFactionFlagsPerHour;
    private bool _isBestFactionFlags;
    private bool _isBestFactionCoins;
    private CityFaction _cityFaction;
    private int _numberOfDungeonFloors;
    private string _diedMessage;
    private bool? _isSelectedForDeletion = false;
    private bool _isVisible;
    private Tier _tier = Tier.Unknown;
    private double _might;
    private double _favor;
    private double _mightPerHour;
    private double _favorPerHour;
    private bool _isMightFavorVisible;
    private bool _isBestMight;
    private bool _isBestFavor;
    private bool _isBestMightPerHour;
    private bool _isBestFavorPerHour;

    public string DungeonHash => $"{EnterDungeonFirstTime.Ticks}{string.Join(",", GuidList)}";

    public DungeonNotificationFragment(int dungeonNumber, List<Guid> guidList, string mainMapIndex, DateTime enterDungeonFirstTime)
    {
        DungeonNumber = dungeonNumber;
        MainMapIndex = mainMapIndex;
        GuidList = guidList;
        EnterDungeonFirstTime = enterDungeonFirstTime;
        Faction = Faction.Unknown;
    }

    public void SetValues(DungeonObject dungeonObject)
    {
        TotalRunTimeInSeconds = dungeonObject.TotalRunTimeInSeconds;
        DiedInDungeon = dungeonObject.DiedInDungeon;
        DiedName = dungeonObject.DiedName;
        KilledBy = dungeonObject.KilledBy;
        Faction = dungeonObject.Faction;
        Fame = dungeonObject.Fame;
        ReSpec = dungeonObject.ReSpec;
        Silver = dungeonObject.Silver;
        CityFaction = dungeonObject.CityFaction;
        FactionCoins = dungeonObject.FactionCoins;
        FactionFlags = dungeonObject.FactionFlags;
        Might = dungeonObject.Might;
        Favor = dungeonObject.Favor;
        Mode = dungeonObject.Mode;
        Status = dungeonObject.Status;
        Tier = dungeonObject.Tier;

        UpdateChests(dungeonObject.DungeonEventObjects.ToAsyncEnumerable());
    }

    private async void UpdateChests(IAsyncEnumerable<DungeonEventObject> dungeonEventObjects)
    {
        foreach (var dungeonEventObject in await dungeonEventObjects.ToListAsync().ConfigureAwait(false))
        {
            var dungeon = DungeonChests?.FirstOrDefault(x => x.Hash == dungeonEventObject.Hash);

            if (dungeon != null)
            {
                dungeon.IsBossChest = dungeonEventObject.IsBossChest;
                dungeon.IsChestOpen = dungeonEventObject.IsOpen;
                dungeon.Opened = dungeonEventObject.Opened;
                dungeon.Rarity = dungeonEventObject.Rarity;
                dungeon.Type = dungeonEventObject.ObjectType;
                dungeon.UniqueName = dungeonEventObject.UniqueName;
                dungeon.ShrineType = dungeonEventObject.ShrineType;
                dungeon.ShrineBuff = dungeonEventObject.ShrineBuff;
            }
            else
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    DungeonChests?.Add(new DungeonEventObjectFragment()
                    {
                        Id = dungeonEventObject.Id,
                        IsBossChest = dungeonEventObject.IsBossChest,
                        IsChestOpen = dungeonEventObject.IsOpen,
                        Opened = dungeonEventObject.Opened,
                        Rarity = dungeonEventObject.Rarity,
                        Type = dungeonEventObject.ObjectType,
                        UniqueName = dungeonEventObject.UniqueName,
                        ShrineType = dungeonEventObject.ShrineType,
                        ShrineBuff = dungeonEventObject.ShrineBuff
                    });
                });
            }
        }
    }

    public string TierString
    {
        get
        {
            return Tier switch
            {
                Tier.T1 => "I",
                Tier.T2 => "II",
                Tier.T3 => "III",
                Tier.T4 => "IV",
                Tier.T5 => "V",
                Tier.T6 => "VI",
                Tier.T7 => "VII",
                Tier.T8 => "VIII",
                Tier.Unknown => "?",
                _ => "?"
            };
        }
    }

    public ObservableCollection<DungeonEventObjectFragment> DungeonChests
    {
        get => _dungeonChests;
        set => this.RaiseAndSetIfChanged(ref _dungeonChests, value);
    }

    public int DungeonNumber
    {
        get => _dungeonNumber;
        set => this.RaiseAndSetIfChanged(ref _dungeonNumber, value);
    }

    public bool IsVisible
    {
        get => _isVisible;
        set => this.RaiseAndSetIfChanged(ref _isVisible, value);
    }

    public Faction Faction
    {
        get => _faction;
        set => this.RaiseAndSetIfChanged(ref _faction, value);
    }

    public DungeonMode Mode
    {
        get => _mode;
        set => this.RaiseAndSetIfChanged(ref _mode, value);
    }

    public CityFaction CityFaction
    {
        get => _cityFaction;
        set => this.RaiseAndSetIfChanged(ref _cityFaction, value);
    }

    public Tier Tier
    {
        get => _tier;
        set => this.RaiseAndSetIfChanged(ref _tier, value);
    }

    public string MainMapIndex
    {
        get => _mainMapIndex;
        set
        {
            _mainMapIndex = value;
            MainMapName = WorldData.GetUniqueNameOrDefault(value);
            this.RaiseAndSetIfChanged(ref _mainMapIndex, value);
        }
    }

    public string MainMapName
    {
        get => _mainMapName;
        set => this.RaiseAndSetIfChanged(ref _mainMapName, value);
    }

    public bool DiedInDungeon
    {
        get => _diedInDungeon;
        set
        {
            _diedInDungeon = value;
            DiedMessage = $"{DiedName} {LanguageController.Translation("KILLED_BY")} {KilledBy}";
            this.RaiseAndSetIfChanged(ref _diedInDungeon, value);
        }
    }

    public string DiedMessage
    {
        get => _diedMessage;
        set => this.RaiseAndSetIfChanged(ref _diedMessage, value);
    }

    public string? DiedName
    {
        get => _diedName;
        set => this.RaiseAndSetIfChanged(ref _diedName, value);
    }

    public string? KilledBy
    {
        get => _killedBy;
        set => this.RaiseAndSetIfChanged(ref _killedBy, value);
    }

    public DateTime EnterDungeonFirstTime
    {
        get => _enterDungeonFirstTime;
        set => this.RaiseAndSetIfChanged(ref _enterDungeonFirstTime, value);
    }

    public string RunTimeString
    {
        get => _runTimeString;
        set => this.RaiseAndSetIfChanged(ref _runTimeString, value);
    }

    public int TotalRunTimeInSeconds
    {
        get => _totalRunTimeInSeconds;
        set
        {
            _totalRunTimeInSeconds = value;
            RunTimeString = value.ToTimerString() ?? "0";
            NumberOfDungeonFloors = GuidList?.Count ?? 0;
            this.RaiseAndSetIfChanged(ref _totalRunTimeInSeconds, value);
        }
    }

    public List<Guid> GuidList
    {
        get => _guidList;
        set
        {
            _guidList = value;
            NumberOfDungeonFloors = value?.Count ?? 0;
            this.RaiseAndSetIfChanged(ref _guidList, value);
        }
    }

    public int NumberOfDungeonFloors
    {
        get => _numberOfDungeonFloors;
        set => this.RaiseAndSetIfChanged(ref _numberOfDungeonFloors, value);
    }

    public double Fame
    {
        get => _fame;
        private set
        {
            _fame = value;
            FamePerHour = Utilities.GetValuePerHourToDouble(Fame, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);
            this.RaiseAndSetIfChanged(ref _fame, value);
        }
    }

    public double ReSpec
    {
        get => _reSpec;
        private set
        {
            _reSpec = value;
            ReSpecPerHour = Utilities.GetValuePerHourToDouble(ReSpec, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);
            this.RaiseAndSetIfChanged(ref _reSpec, value);
        }
    }

    public double Silver
    {
        get => _silver;
        private set
        {
            _silver = value;
            SilverPerHour = Utilities.GetValuePerHourToDouble(Silver, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);
            this.RaiseAndSetIfChanged(ref _silver, value);
        }
    }

    public double FactionFlags
    {
        get => _factionFlags;
        private set
        {
            _factionFlags = value;
            FactionFlagsPerHour = Utilities.GetValuePerHourToDouble(FactionFlags, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);
            this.RaiseAndSetIfChanged(ref _factionFlags, value);
        }
    }

    public double FactionCoins
    {
        get => _factionCoins;
        private set
        {
            _factionCoins = value;
            FactionCoinsPerHour = Utilities.GetValuePerHourToDouble(FactionCoins, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);

            if (FactionCoins > 0 && IsFactionWarfareVisible == !IsVisible && IsMightFavorVisible == false)
            {
                IsFactionWarfareVisible = true;
            }
            this.RaiseAndSetIfChanged(ref _factionCoins, value);
        }
    }

    public double FactionFlagsPerHour
    {
        get
        {
            if (double.IsNaN(_factionFlagsPerHour))
            {
                return 0;
            }

            return _factionFlagsPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _factionFlagsPerHour, value);
    }

    public double FactionCoinsPerHour
    {
        get
        {
            if (double.IsNaN(_factionCoinsPerHour))
            {
                return 0;
            }

            return _factionCoinsPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _factionCoinsPerHour, value);
    }

    public double Might
    {
        get => _might;
        // ReSharper disable once UnusedMember.Local
        private set
        {
            _might = value;
            MightPerHour = Utilities.GetValuePerHourToDouble(Might, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);

            if (Might > 0 && IsMightFavorVisible == false)
            {
                IsMightFavorVisible = true;
                IsFactionWarfareVisible = false;
            }
            this.RaiseAndSetIfChanged(ref _might, value);
        }
    }

    public double Favor
    {
        get => _favor;
        // ReSharper disable once UnusedMember.Local
        private set
        {
            _favor = value;
            FavorPerHour = Utilities.GetValuePerHourToDouble(Favor, TotalRunTimeInSeconds <= 0 ? (DateTime.UtcNow - EnterDungeonFirstTime).Seconds : TotalRunTimeInSeconds);

            if (Favor > 0 && IsMightFavorVisible == false)
            {
                IsMightFavorVisible = true;
                IsFactionWarfareVisible = false;
            }
            this.RaiseAndSetIfChanged(ref _favor, value);
        }
    }

    public double MightPerHour
    {
        get
        {
            if (double.IsNaN(_mightPerHour))
            {
                return 0;
            }

            return _mightPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _mightPerHour, value);
    }

    public double FavorPerHour
    {
        get
        {
            if (double.IsNaN(_favorPerHour))
            {
                return 0;
            }

            return _favorPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _favorPerHour, value);
    }

    public double FamePerHour
    {
        get
        {
            if (double.IsNaN(_famePerHour))
            {
                return 0;
            }

            return _famePerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _famePerHour, value);
    }

    public double ReSpecPerHour
    {
        get
        {
            if (double.IsNaN(_reSpecPerHour))
            {
                return 0;
            }

            return _reSpecPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _reSpecPerHour, value);
    }

    public double SilverPerHour
    {
        get
        {
            if (double.IsNaN(_silverPerHour))
            {
                return 0;
            }

            return _silverPerHour;
        }
        private set => this.RaiseAndSetIfChanged(ref _silverPerHour, value);
    }

    public DungeonStatus Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }

    public bool IsFactionWarfareVisible
    {
        get => _isFactionWarfareVisible;
        set => this.RaiseAndSetIfChanged(ref _isFactionWarfareVisible, value);
    }

    public bool IsMightFavorVisible
    {
        get => _isMightFavorVisible;
        set => this.RaiseAndSetIfChanged(ref _isMightFavorVisible, value);
    }

    public bool IsBestTime
    {
        get => _isBestTime;
        set => this.RaiseAndSetIfChanged(ref _isBestTime, value);
    }

    public bool IsBestFame
    {
        get => _isBestFame;
        set => this.RaiseAndSetIfChanged(ref _isBestFame, value);
    }

    public bool IsBestReSpec
    {
        get => _isBestReSpec;
        set => this.RaiseAndSetIfChanged(ref _isBestReSpec, value);
    }

    public bool IsBestSilver
    {
        get => _isBestSilver;
        set => this.RaiseAndSetIfChanged(ref _isBestSilver, value);
    }

    public bool IsBestFactionCoins
    {
        get => _isBestFactionCoins;
        set => this.RaiseAndSetIfChanged(ref _isBestFactionCoins, value);
    }

    public bool IsBestFactionFlags
    {
        get => _isBestFactionFlags;
        set => this.RaiseAndSetIfChanged(ref _isBestFactionFlags, value);
    }

    public bool IsBestFactionFlagsPerHour
    {
        get => _isBestFactionFlagsPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestFactionFlagsPerHour, value);
    }

    public bool IsBestFactionCoinsPerHour
    {
        get => _isBestFactionCoinsPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestFactionCoinsPerHour, value);
    }

    public bool IsBestMight
    {
        get => _isBestMight;
        set => this.RaiseAndSetIfChanged(ref _isBestMight, value);
    }

    public bool IsBestFavor
    {
        get => _isBestFavor;
        set => this.RaiseAndSetIfChanged(ref _isBestFavor, value);
    }

    public bool IsBestMightPerHour
    {
        get => _isBestMightPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestMightPerHour, value);
    }

    public bool IsBestFavorPerHour
    {
        get => _isBestFavorPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestFavorPerHour, value);
    }

    public bool IsBestFamePerHour
    {
        get => _isBestFamePerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestFamePerHour, value);
    }

    public bool IsBestReSpecPerHour
    {
        get => _isBestReSpecPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestReSpecPerHour, value);
    }

    public bool IsBestSilverPerHour
    {
        get => _isBestSilverPerHour;
        set => this.RaiseAndSetIfChanged(ref _isBestSilverPerHour, value);
    }

    public bool? IsSelectedForDeletion
    {
        get => _isSelectedForDeletion;
        set => this.RaiseAndSetIfChanged(ref _isSelectedForDeletion, value);
    }

    [JsonIgnore] public static string TranslationSelectToDelete => LanguageController.Translation("SELECT_TO_DELETE");
    [JsonIgnore] public static string TranslationDungeonFame => LanguageController.Translation("DUNGEON_FAME");
    [JsonIgnore] public static string TranslationDungeonReSpec => LanguageController.Translation("DUNGEON_RESPEC");
    [JsonIgnore] public static string TranslationDungeonSilver => LanguageController.Translation("DUNGEON_SILVER");
    [JsonIgnore] public static string TranslationDungeonFamePerHour => LanguageController.Translation("DUNGEON_FAME_PER_HOUR");
    [JsonIgnore] public static string TranslationDungeonReSpecPerHour => LanguageController.Translation("DUNGEON_RESPEC_PER_HOUR");
    [JsonIgnore] public static string TranslationDungeonSilverPerHour => LanguageController.Translation("DUNGEON_SILVER_PER_HOUR");
    [JsonIgnore] public static string TranslationDungeonRunTime => LanguageController.Translation("DUNGEON_RUN_TIME");
    [JsonIgnore] public static string TranslationNumberOfDungeonFloors => LanguageController.Translation("NUMBER_OF_DUNGEON_FLOORS");
    [JsonIgnore] public static string TranslationExpedition => LanguageController.Translation("EXPEDITION");
    [JsonIgnore] public static string TranslationSolo => LanguageController.Translation("SOLO");
    [JsonIgnore] public static string TranslationStandard => LanguageController.Translation("STANDARD");
    [JsonIgnore] public static string TranslationAvalon => LanguageController.Translation("AVALON");
    [JsonIgnore] public static string TranslationUnknown => LanguageController.Translation("UNKNOWN");
    [JsonIgnore] public static string TranslationFactionFlags => LanguageController.Translation("FACTION_FLAGS");
    [JsonIgnore] public static string TranslationFactionFlagsPerHour => LanguageController.Translation("FACTION_FLAGS_PER_HOUR");
    [JsonIgnore] public static string TranslationFactionCoins => LanguageController.Translation("FACTION_COINS");
    [JsonIgnore] public static string TranslationFactionCoinsPerHour => LanguageController.Translation("FACTION_COINS_PER_HOUR");
    [JsonIgnore] public static string TranslationMight => LanguageController.Translation("MIGHT");
    [JsonIgnore] public static string TranslationMightPerHour => LanguageController.Translation("MIGHT_PER_HOUR");
    [JsonIgnore] public static string TranslationFavor => LanguageController.Translation("FAVOR");
    [JsonIgnore] public static string TranslationFavorPerHour => LanguageController.Translation("FAVOR_PER_HOUR");
}