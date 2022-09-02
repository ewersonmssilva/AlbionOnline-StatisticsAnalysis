using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.BindingModels;

public class TrackingActivityBindings : ReactiveObject
{
    private TrackingIconType _trackingActivityType = TrackingIconType.Off;
    private string _trackingActiveText = LanguageController.Translation("TRACKING_IS_NOT_ACTIVE");
    private bool _characterIsNotTrackedInfoVisibility;

    public TrackingIconType TrackingActivityType
    {
        get => _trackingActivityType;
        set => this.RaiseAndSetIfChanged(ref _trackingActivityType, value);
    }

    public string TrackingActiveText
    {
        get => _trackingActiveText;
        set => this.RaiseAndSetIfChanged(ref _trackingActiveText, value);
    }

    public bool CharacterIsNotTrackedInfoVisibility
    {
        get => _characterIsNotTrackedInfoVisibility;
        set => this.RaiseAndSetIfChanged(ref _characterIsNotTrackedInfoVisibility, value);
    }
}