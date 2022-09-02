using Avalonia.Threading;
using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using System;
using System.Windows.Input;

namespace StatisticsAnalysisTool.Avalonia.Models.NetworkModel;

public class DungeonCloseTimer : ReactiveObject
{
    private string _timerString;
    private bool _isDungeonClosed;
    private DateTime _endTime;
    private bool _isVisible;
    private readonly DispatcherTimer _dispatcherTimer = new();

    public DungeonCloseTimer()
    {
        _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        _dispatcherTimer.Tick += UpdateTimer;
    }

    public bool IsDungeonClosed
    {
        get => _isDungeonClosed;
        private set => this.RaiseAndSetIfChanged(ref _isDungeonClosed, value);
    }

    public string TimerString
    {
        get => _timerString;
        set => this.RaiseAndSetIfChanged(ref _timerString, value);
    }

    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            _isVisible = value;

            switch (_isVisible)
            {
                case true when !_dispatcherTimer.IsEnabled:
                    _endTime = DateTime.UtcNow.AddSeconds(90);
                    IsDungeonClosed = false;
                    _dispatcherTimer.Start();
                    break;
                case false when _dispatcherTimer.IsEnabled:
                    _dispatcherTimer.Stop();
                    break;
            }

            this.RaiseAndSetIfChanged(ref _isVisible, value);
        }
    }

    public void UpdateTimer(object sender, EventArgs e)
    {
        var duration = _endTime - DateTime.UtcNow;
        TimerString = duration.ToString("hh\\:mm\\:ss");

        if (duration.TotalSeconds <= 0)
        {
            IsDungeonClosed = true;
            _dispatcherTimer.Stop();
        }
    }

    private void PerformRefreshDungeonTimer(object value)
    {
        _endTime = DateTime.UtcNow.AddSeconds(90);

        if (!_dispatcherTimer.IsEnabled)
        {
            IsDungeonClosed = false;
            _dispatcherTimer.Start();
        }
    }

    private ICommand _refreshDungeonTimer;

    // TODO: Command handler adjustment
    //public ICommand RefreshDungeonTimer => _refreshDungeonTimer ??= new CommandHandler(PerformRefreshDungeonTimer, true);

    public static string TranslationSafe => LanguageController.Translation("SAFE");
    public static string TranslationDungeonTimer => LanguageController.Translation("DUNGEON_TIMER");
    public static string TranslationResetDungeonTimer => LanguageController.Translation("RESET_DUNGEON_TIMER");
}