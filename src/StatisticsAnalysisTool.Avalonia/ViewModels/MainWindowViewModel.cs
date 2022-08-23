using ReactiveUI.Fody.Helpers;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Controls;
using System;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, ICloseWindow
    {
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
