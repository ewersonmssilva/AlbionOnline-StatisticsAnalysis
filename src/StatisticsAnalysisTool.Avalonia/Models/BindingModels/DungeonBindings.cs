using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Settings;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using StatisticsAnalysisTool.Avalonia.Common.Comparer;
using StatisticsAnalysisTool.Avalonia.Models.NetworkModel;
using StatisticsAnalysisTool.Avalonia.Network.Notification;

namespace StatisticsAnalysisTool.Avalonia.Models.BindingModels;

public class DungeonBindings : ReactiveObject
{
    private ObservableCollection<DungeonNotificationFragment> _trackingDungeons = new();
    private ListCollectionView? _trackingDungeonsCollectionView;
    private DungeonCloseTimer _dungeonCloseTimer = new();
    private DungeonStatsFilter _dungeonStatsFilter;
    private DungeonStats _dungeonStatsDay = new();
    private DungeonStats _dungeonStatsTotal = new();
    private GridLength _gridSplitterPosition;

    public DungeonBindings()
    {
        // TODO: CollectionViewSource.GetDefaultView korrekt implemenbtieren
        //TrackingDungeonsCollectionView = CollectionViewSource.GetDefaultView(TrackingDungeons) as ListCollectionView;
        //if (TrackingDungeonsCollectionView != null)
        //{
        //    TrackingDungeonsCollectionView.IsLiveSorting = true;
        //    TrackingDungeonsCollectionView.CustomSort = new DungeonTrackingNumberComparer();
        //}
    }

    public ObservableCollection<DungeonNotificationFragment> TrackingDungeons
    {
        get => _trackingDungeons;
        set => this.RaiseAndSetIfChanged(ref _trackingDungeons, value);
    }

    public ListCollectionView? TrackingDungeonsCollectionView
    {
        get => _trackingDungeonsCollectionView;
        set => this.RaiseAndSetIfChanged(ref _trackingDungeonsCollectionView, value);
    }

    public DungeonCloseTimer DungeonCloseTimer
    {
        get => _dungeonCloseTimer;
        set => this.RaiseAndSetIfChanged(ref _dungeonCloseTimer, value);
    }

    public DungeonStats DungeonStatsDay
    {
        get => _dungeonStatsDay;
        set => this.RaiseAndSetIfChanged(ref _dungeonStatsDay, value);
    }

    public DungeonStats DungeonStatsTotal
    {
        get => _dungeonStatsTotal;
        set => this.RaiseAndSetIfChanged(ref _dungeonStatsTotal, value);
    }

    public DungeonStatsFilter DungeonStatsFilter
    {
        get => _dungeonStatsFilter;
        set => this.RaiseAndSetIfChanged(ref _dungeonStatsFilter, value);
    }

    public GridLength GridSplitterPosition
    {
        get => _gridSplitterPosition;
        set
        {
            _gridSplitterPosition = value;
            SettingsController.CurrentUserSettings.DungeonsGridSplitterPosition = _gridSplitterPosition.Value;
            this.RaiseAndSetIfChanged(ref _gridSplitterPosition, value);
        }
    }
}