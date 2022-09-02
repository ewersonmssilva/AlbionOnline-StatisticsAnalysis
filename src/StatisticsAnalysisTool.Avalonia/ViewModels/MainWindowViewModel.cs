using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Controls;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using StatisticsAnalysisTool.Avalonia.GameData;
using StatisticsAnalysisTool.Avalonia.Models;
using StatisticsAnalysisTool.Avalonia.Models.BindingModels;
using StatisticsAnalysisTool.Avalonia.Models.NetworkModel;
using StatisticsAnalysisTool.Avalonia.Models.TranslationModel;
using StatisticsAnalysisTool.Avalonia.Network;
using StatisticsAnalysisTool.Avalonia.Network.Manager;
using StatisticsAnalysisTool.Avalonia.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, ICloseWindow
    {
        public TrackingController? TrackingController;
        public Action? Close { get; set; }

        private bool _isTrackingActive;

        public MainWindowViewModel()
        {
            if (LanguageController.InitializeLanguage())
            {
                // TODO: Window close funktioniert hier nicht, dialog anzeigen!
                //CloseWindow();
            }
            
            InitData();
            //Initialization = InitTrackingAsync();
        }

        #region Inits

        public Task Initialization { get; init; }
        
        private static void InitData()
        {
            // TODO: Close when file can not load
            var isWorldDataOkay = WorldData.GetDataListFromJson();
            var isDungeonObjectDataOkay = DungeonObjectData.GetDataListFromJson();
        }

        private async Task InitTrackingAsync()
        {
            TrackingController ??= new TrackingController(this, WindowsManager.GetWindow<MainWindow>());

            await StartTrackingAsync();

            //IsDamageMeterTrackingActive = SettingsController.CurrentSettings.IsDamageMeterTrackingActive;
            //IsTrackingPartyLootOnly = SettingsController.CurrentSettings.IsTrackingPartyLootOnly;
            //LoggingBindings.IsTrackingSilver = SettingsController.CurrentSettings.IsTrackingSilver;
            //LoggingBindings.IsTrackingFame = SettingsController.CurrentSettings.IsTrackingFame;
            //LoggingBindings.IsTrackingMobLoot = SettingsController.CurrentSettings.IsTrackingMobLoot;

            //LoggingBindings.NotificationsCollectionView = CollectionViewSource.GetDefaultView(LoggingBindings.TrackingNotifications) as ListCollectionView;
            //if (LoggingBindings?.NotificationsCollectionView != null)
            //{
            //    LoggingBindings.NotificationsCollectionView.IsLiveSorting = true;
            //    LoggingBindings.NotificationsCollectionView.IsLiveFiltering = true;
            //    LoggingBindings.NotificationsCollectionView.SortDescriptions.Add(new SortDescription(nameof(DateTime), ListSortDirection.Descending));
            //}

            //// Logging
            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.Fame)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterFame,
            //    Name = MainWindowTranslation.Fame
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.Silver)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterSilver,
            //    Name = MainWindowTranslation.Silver
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.Faction)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterFaction,
            //    Name = MainWindowTranslation.Faction
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.SeasonPoints)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterSeasonPoints,
            //    Name = MainWindowTranslation.SeasonPoints
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.ConsumableLoot)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterConsumableLoot,
            //    Name = MainWindowTranslation.ConsumableLoot
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.EquipmentLoot)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterEquipmentLoot,
            //    Name = MainWindowTranslation.EquipmentLoot
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.SimpleLoot)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterSimpleLoot,
            //    Name = MainWindowTranslation.SimpleLoot
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.UnknownLoot)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterUnknownLoot,
            //    Name = MainWindowTranslation.UnknownLoot
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.ShowLootFromMob)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsLootFromMobShown,
            //    Name = MainWindowTranslation.ShowLootFromMobs
            //});

            //LoggingBindings?.Filters.Add(new LoggingFilterObject(TrackingController, this, LoggingFilterType.Kill)
            //{
            //    IsSelected = SettingsController.CurrentSettings.IsMainTrackerFilterKill,
            //    Name = MainWindowTranslation.ShowKills
            //});
        }

        #endregion

        #region Tracking

        public async Task StartTrackingAsync()
        {
            if (NetworkManager.IsNetworkCaptureRunning)
            {
                return;
            }

            //await TrackingController?.StatisticController?.LoadFromFileAsync()!;
            //await TrackingController?.MailController?.LoadFromFileAsync()!;
            //await TrackingController?.TreasureController?.LoadFromFileAsync()!;
            await TrackingController?.DungeonController.LoadDungeonFromFileAsync()!;
            //await TrackingController?.VaultController?.LoadFromFileAsync()!;

            TrackingController?.DungeonController.SetDungeonStatsDayUi();
            TrackingController?.DungeonController.SetDungeonStatsTotalUi();
            TrackingController?.DungeonController.SetOrUpdateDungeonsDataUiAsync();

            TrackingController?.ClusterController.RegisterEvents();
            //TrackingController?.LootController.RegisterEvents();
            //TrackingController?.TreasureController?.RegisterEvents();

            TrackingController?.LiveStatsTracker.Start();

            DungeonBindings.DungeonStatsFilter = new DungeonStatsFilter(TrackingController);

            IsTrackingActive = NetworkManager.StartNetworkCapture(this, TrackingController);
            Console.WriteLine(@"### Start Tracking...");
        }

        public async Task StopTrackingAsync()
        {
            NetworkManager.StopNetworkCapture();

            TrackingController.LiveStatsTracker.Stop();

            //TrackingController?.TreasureController.UnregisterEvents();
            //TrackingController?.LootController.UnregisterEvents();
            TrackingController?.ClusterController.UnregisterEvents();

            //await TrackingController?.DungeonController?.SaveInFileAsync()!;
            //await TrackingController?.VaultController?.SaveInFileAsync()!;
            //await TrackingController?.TreasureController?.SaveInFileAsync()!;
            //await TrackingController?.StatisticController?.SaveInFileAsync()!;

            //await FileController.SaveAsync(MailMonitoringBindings?.Mails?.ToList(), $"{AppDomain.CurrentDomain.BaseDirectory}{Settings.Default.MailsFileName}");
            //await FileController.SaveAsync(DamageMeterBindings?.DamageMeterSnapshots, $"{AppDomain.CurrentDomain.BaseDirectory}{Settings.Default.DamageMeterSnapshotsFileName}");

            IsTrackingActive = false;
            Console.WriteLine(@"### Stop Tracking");
        }

        #endregion

        public void CloseWindow()
        {
            Close?.Invoke();
        }

        #region Bindings

        public bool IsTrackingActive
        {
            get => _isTrackingActive;
            set
            {
                _isTrackingActive = value;

                switch (_isTrackingActive)
                {
                    case true when TrackingController is { ExistIndispensableInfos: false }:
                        TrackingActivityBindings.TrackingActiveText = MainWindowTranslation.TrackingIsPartiallyActive;
                        TrackingActivityBindings.TrackingActivityType = TrackingIconType.Partially;
                        break;
                    case true when TrackingController is { ExistIndispensableInfos: true }:
                        TrackingActivityBindings.TrackingActiveText = MainWindowTranslation.TrackingIsActive;
                        TrackingActivityBindings.TrackingActivityType = TrackingIconType.On;
                        break;
                    case false:
                        TrackingActivityBindings.TrackingActiveText = MainWindowTranslation.TrackingIsNotActive;
                        TrackingActivityBindings.TrackingActivityType = TrackingIconType.Off;
                        break;
                }

                this.RaiseAndSetIfChanged(ref _isTrackingActive, value);
            }
        }

        [Reactive]
        public string? MainTrackerTimer { get; set; }

        [Reactive]
        public ObservableCollection<MainStatObject>? FactionPointStats { get; set; }

        [Reactive]
        public bool IsTrackingResetByMapChangeActive { get; set; }

        [Reactive]
        public DashboardBindings DashboardBindings { get; set; } = new();

        [Reactive]
        public DungeonBindings DungeonBindings { get; set; } = new();

        [Reactive]
        public UserTrackingBindings UserTrackingBindings { get; set; } = new();

        [Reactive]
        public ObservableCollection<ClusterInfo> EnteredCluster { get; set; } = new();

        [Reactive]
        public int PartyMemberNumber { get; set; }

        [Reactive]
        public ObservableCollection<PartyMemberCircle> PartyMemberCircles { get; set; } = new();

        [Reactive]
        public TrackingActivityBindings TrackingActivityBindings { get; set; } = new();

        [Reactive]
        public bool DebugModeVisibility
        {
            get
            {
                // ReSharper disable once JoinDeclarationAndInitializer
                bool isDebugMode;
#if DEBUG
                isDebugMode = true;
#endif
                return isDebugMode;
            }
        }

        [Reactive]
        public ItemSearchViewModel ItemSearchViewModel { get; set; } = new ();

        [Reactive]
        public TrackingGeneralViewModel TrackingGeneralViewModel { get; set; } = new();

        [Reactive]
        public ViewModelBase FooterViewModel { get; set; } = new();

        #endregion
    }
}
