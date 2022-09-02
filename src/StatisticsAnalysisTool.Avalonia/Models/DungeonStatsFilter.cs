using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using StatisticsAnalysisTool.Avalonia.Network.Manager;
using System.Collections.Generic;

namespace StatisticsAnalysisTool.Avalonia.Models
{
    public class DungeonStatsFilter : ReactiveObject
    {
        private bool? _soloCheckbox = true;
        private bool? _standardCheckbox = true;
        private bool? _avaCheckbox = true;
        private bool? _hgCheckbox = true;
        private bool? _expeditionCheckbox = true;
        private bool? _corruptedCheckbox = true;
        private bool? _unknownCheckbox = true;
        private List<DungeonMode> _dungeonModeFilters = new()
        {
            DungeonMode.Solo,
            DungeonMode.Standard,
            DungeonMode.Avalon,
            DungeonMode.HellGate,
            DungeonMode.Expedition,
            DungeonMode.Corrupted,
            DungeonMode.Unknown
        };
        private readonly TrackingController _trackingController;

        public DungeonStatsFilter(TrackingController trackingController)
        {
            _trackingController = trackingController;

            _trackingController?.DungeonController?.SetDungeonStatsDayUi();
            _trackingController?.DungeonController?.SetDungeonStatsTotalUi();
        }

        public bool? SoloCheckbox
        {
            get => _soloCheckbox;
            set
            {
                _soloCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Solo, _soloCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _soloCheckbox, value);
            }
        }

        public bool? StandardCheckbox
        {
            get => _standardCheckbox;
            set
            {
                _standardCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Standard, _standardCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _standardCheckbox, value);
            }
        }

        public bool? AvaCheckbox
        {
            get => _avaCheckbox;
            set
            {
                _avaCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Avalon, _avaCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _avaCheckbox, value);
            }
        }

        public bool? HgCheckbox
        {
            get => _hgCheckbox;
            set
            {
                _hgCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.HellGate, _hgCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _hgCheckbox, value);
            }
        }

        public bool? ExpeditionCheckbox
        {
            get => _expeditionCheckbox;
            set
            {
                _expeditionCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Expedition, _expeditionCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _expeditionCheckbox, value);
            }
        }

        public bool? CorruptedCheckbox
        {
            get => _corruptedCheckbox;
            set
            {
                _corruptedCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Corrupted, _corruptedCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _corruptedCheckbox, value);
            }
        }

        public bool? UnknownCheckbox
        {
            get => _unknownCheckbox;
            set
            {
                _unknownCheckbox = value;
                ChangeDungeonModeFilter(DungeonMode.Unknown, _unknownCheckbox ?? false);
                this.RaiseAndSetIfChanged(ref _unknownCheckbox, value);
            }
        }

        public List<DungeonMode> DungeonModeFilters
        {
            get => _dungeonModeFilters;
            set
            {
                _dungeonModeFilters = value;
                this.RaiseAndSetIfChanged(ref _dungeonModeFilters, value);
            }
        }

        private void ChangeDungeonModeFilter(DungeonMode dungeonMode, bool filterStatus)
        {
            if (filterStatus)
            {
                AddDungeonMode(dungeonMode);
            }
            else
            {
                RemoveDungeonMode(dungeonMode);
            }

            _trackingController?.DungeonController?.SetOrUpdateDungeonsDataUiAsync();
        }

        private void AddDungeonMode(DungeonMode dungeonMode)
        {
            if (!_dungeonModeFilters.Exists(x => x == dungeonMode))
            {
                _dungeonModeFilters.Add(dungeonMode);
            }
        }

        private void RemoveDungeonMode(DungeonMode dungeonMode)
        {
            if (_dungeonModeFilters.Exists(x => x == dungeonMode))
            {
                _dungeonModeFilters.Remove(dungeonMode);
            }
        }

        public static string TranslationFilter => LanguageController.Translation("FILTER");
        public static string TranslationSolo => LanguageController.Translation("SOLO");
        public static string TranslationSoloDungeon => LanguageController.Translation("SOLO_DUNGEON");
        public static string TranslationStandard => LanguageController.Translation("STANDARD");
        public static string TranslationStandardDungeon => LanguageController.Translation("STANDARD_DUNGEON");
        public static string TranslationAva => LanguageController.Translation("AVA");
        public static string TranslationAvalonianDungeon => LanguageController.Translation("AVALONIAN_DUNGEON");
        public static string TranslationHg => LanguageController.Translation("HG");
        public static string TranslationHellGate => LanguageController.Translation("HELLGATE");
        public static string TranslationCorrupted => LanguageController.Translation("CORRUPTED");
        public static string TranslationCorruptedDungeon => LanguageController.Translation("CORRUPTED_LAIR");
        public static string TranslationExped => LanguageController.Translation("EXPED");
        public static string TranslationExpedition => LanguageController.Translation("EXPEDITION");
        public static string TranslationUnknown => LanguageController.Translation("UNKNOWN");
    }
}