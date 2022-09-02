using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;

namespace StatisticsAnalysisTool.Avalonia.Models
{
    public class DungeonStats : ReactiveObject
    {
        private int _enteredDungeon;
        private int _openedLegendaryChests;
        private int _openedRareChests;
        private int _openedStandardChests;
        private int _openedUncommonChests;
        private double _fame;
        private double _reSpec;
        private double _silver;
        private string? _translationTitle;
        private double _fameAverage;
        private double _reSpecAverage;
        private double _silverAverage;

        public int EnteredDungeon
        {
            get => _enteredDungeon;
            set
            {
                _enteredDungeon = value;
                this.RaiseAndSetIfChanged(ref _enteredDungeon, value);
            }
        }

        public int OpenedStandardChests
        {
            get => _openedStandardChests;
            set => this.RaiseAndSetIfChanged(ref _openedStandardChests, value);
        }

        public int OpenedUncommonChests
        {
            get => _openedUncommonChests;
            set => this.RaiseAndSetIfChanged(ref _openedUncommonChests, value);
        }

        public int OpenedRareChests
        {
            get => _openedRareChests;
            set => this.RaiseAndSetIfChanged(ref _openedRareChests, value);
        }

        public int OpenedLegendaryChests
        {
            get => _openedLegendaryChests;
            set => this.RaiseAndSetIfChanged(ref _openedLegendaryChests, value);
        }

        public double Fame
        {
            get => _fame;
            set
            {
                _fame = value;

                FameAverage = (value / EnteredDungeon).ToShortNumber(99999999.99);
                this.RaiseAndSetIfChanged(ref _fame, value);
            }
        }

        public double ReSpec
        {
            get => _reSpec;
            set
            {
                _reSpec = value;
                ReSpecAverage = (value / EnteredDungeon).ToShortNumber(99999999.99);
                this.RaiseAndSetIfChanged(ref _reSpec, value);
            }
        }

        public double Silver
        {
            get => _silver;
            set
            {
                _silver = value;
                SilverAverage = (value / EnteredDungeon).ToShortNumber(99999999.99);
                this.RaiseAndSetIfChanged(ref _silver, value);
            }
        }

        public double FameAverage
        {
            get => _fameAverage;
            set
            {
                _fameAverage = value;
                this.RaiseAndSetIfChanged(ref _fameAverage, value);
            }
        }

        public double ReSpecAverage
        {
            get => _reSpecAverage;
            set
            {
                _reSpecAverage = value;
                this.RaiseAndSetIfChanged(ref _reSpecAverage, value);
            }
        }

        public double SilverAverage
        {
            get => _silverAverage;
            set
            {
                _silverAverage = value;
                this.RaiseAndSetIfChanged(ref _silverAverage, value);
            }
        }

        public string? TranslationTitle
        {
            get => _translationTitle;
            set
            {
                _translationTitle = value;
                this.RaiseAndSetIfChanged(ref _translationTitle, value);
            }
        }

        public static string TranslationEnteredDungeon => LanguageController.Translation("ENTERED_DUNGEON");
        public static string TranslationOpenedStandardChests => LanguageController.Translation("OPENED_STANDARD_CHESTS");
        public static string TranslationOpenedUncommonChests => LanguageController.Translation("OPENED_UNCOMMON_CHESTS");
        public static string TranslationOpenedRareChests => LanguageController.Translation("OPENED_RARE_CHESTS");
        public static string TranslationOpenedLegendaryChests => LanguageController.Translation("OPENED_LEGENDARY_CHESTS");
        public static string TranslationFame => LanguageController.Translation("FAME");
        public static string TranslationReSpec => LanguageController.Translation("RESPEC");
        public static string TranslationSilver => LanguageController.Translation("SILVER");
        public static string TranslationAverageFame => LanguageController.Translation("AVERAGE_FAME");
        public static string TranslationAverageReSpec => LanguageController.Translation("AVERAGE_RESPEC");
        public static string TranslationAverageSilver => LanguageController.Translation("AVERAGE_SILVER");
    }
}