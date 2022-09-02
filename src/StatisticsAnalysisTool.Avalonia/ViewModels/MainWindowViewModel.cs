using ReactiveUI.Fody.Helpers;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Controls;
using StatisticsAnalysisTool.Avalonia.Models;
using StatisticsAnalysisTool.Avalonia.Models.BindingModels;
using StatisticsAnalysisTool.Avalonia.Models.NetworkModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StatisticsAnalysisTool.Avalonia.Network.Manager;

namespace StatisticsAnalysisTool.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, ICloseWindow
    {
        public TrackingController TrackingController;
        public Action? Close { get; set; }

        public MainWindowViewModel()
        {
            _ = InitUiAsync();

            if (LanguageController.InitializeLanguage())
            {
                // TODO: Window close funktioniert hier nicht, dialog anzeigen!
                //CloseWindow();
            }

            ItemSearchViewModel = new ItemSearchViewModel();
            TrackingGeneralViewModel = new TrackingGeneralViewModel();
            FooterViewModel = new FooterViewModel();
        }

        #region Inits

        private async Task InitUiAsync()
        {
#if DEBUG
            DebugModeVisibility = true;
#endif

            await Task.CompletedTask;
        }

        #endregion

        public void CloseWindow()
        {
            Close?.Invoke();
        }

        #region Bindings

        [Reactive]
        public string MainTrackerTimer { get; set; }

        [Reactive]
        public ObservableCollection<MainStatObject> FactionPointStats { get; set; }

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
        public bool DebugModeVisibility { get; set; }

        [Reactive]
        public ItemSearchViewModel ItemSearchViewModel { get; set; }

        [Reactive]
        public TrackingGeneralViewModel TrackingGeneralViewModel { get; set; }

        [Reactive]
        public ViewModelBase FooterViewModel { get; set; }

        #endregion
    }
}
