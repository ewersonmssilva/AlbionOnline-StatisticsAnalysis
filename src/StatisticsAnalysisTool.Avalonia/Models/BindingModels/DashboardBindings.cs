using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsAnalysisTool.Avalonia.Models.BindingModels
{
    public class DashboardBindings : ReactiveObject
    {
        private double _famePerHour;
        private double _reSpecPointsPerHour;
        private double _silverPerHour;
        private double _mightPerHour;
        private double _favorPerHour;
        private double _silverCostForReSpecHour;
        private double _totalGainedFameInSessionInSession;
        private double _totalGainedReSpecPointsInSessionInSession;
        private double _totalGainedSilverInSessionInSession;
        private double _totalGainedMightInSession;
        private double _totalGainedFavorInSession;
        private double _totalSilverCostForReSpecInSession;
        private double _highestValue;
        private double _fameInPercent;
        private double _silverInPercent;
        private double _reSpecPointsInPercent;
        private double _mightInPercent;
        private double _favorInPercent;
        private int _killsToday;
        private int _deathsToday;
        private int _killsThisWeek;
        private int _deathsThisWeek;
        private DateTime? _lastUpdate;
        private double _averageItemPowerWhenKilling;
        private double _averageItemPowerOfTheKilledEnemies;
        private double _averageItemPowerWhenDying;
        private int _killsThisMonth;
        private int _deathsThisMonth;
        private int _soloKillsToday;
        private int _soloKillsThisWeek;
        private int _soloKillsThisMonth;
        private LootedChests _lootedChests = new();

        #region Fame / Respec / Silver / Might / Faction

        public double GetHighestValue()
        {
            var values = new List<double>()
            {
                TotalGainedFameInSession,
                TotalGainedSilverInSession,
                TotalGainedReSpecPointsInSession,
                TotalGainedMightInSession,
                TotalGainedFavorInSession
            };

            return values.Max<double>();
        }

        public void Reset()
        {
            HighestValue = 0;

            FamePerHour = 0;
            SilverPerHour = 0;
            ReSpecPointsPerHour = 0;
            MightPerHour = 0;
            FavorPerHour = 0;

            TotalGainedFameInSession = 0;
            TotalGainedSilverInSession = 0;
            TotalGainedReSpecPointsInSession = 0;
            TotalGainedMightInSession = 0;
            TotalGainedFavorInSession = 0;
        }

        #region Per hour values

        public double HighestValue
        {
            get => _highestValue;
            set => this.RaiseAndSetIfChanged(ref _highestValue, value);
        }

        public double FamePerHour
        {
            get => _famePerHour;
            set => this.RaiseAndSetIfChanged(ref _famePerHour, value);
        }

        public double SilverPerHour
        {
            get => _silverPerHour;
            set => this.RaiseAndSetIfChanged(ref _silverPerHour, value);
        }

        public double ReSpecPointsPerHour
        {
            get => _reSpecPointsPerHour;
            set => this.RaiseAndSetIfChanged(ref _reSpecPointsPerHour, value);
        }

        public double MightPerHour
        {
            get => _mightPerHour;
            set => this.RaiseAndSetIfChanged(ref _mightPerHour, value);
        }

        public double FavorPerHour
        {
            get => _favorPerHour;
            set => this.RaiseAndSetIfChanged(ref _favorPerHour, value);
        }

        public double SilverCostForReSpecHour
        {
            get => _silverCostForReSpecHour;
            set => this.RaiseAndSetIfChanged(ref _silverCostForReSpecHour, value);
        }

        #endregion

        #region Percent values

        public double FameInPercent
        {
            get => _fameInPercent;
            set => this.RaiseAndSetIfChanged(ref _fameInPercent, value);
        }

        public double SilverInPercent
        {
            get => _silverInPercent;
            set => this.RaiseAndSetIfChanged(ref _silverInPercent, value);
        }

        public double ReSpecPointsInPercent
        {
            get => _reSpecPointsInPercent;
            set => this.RaiseAndSetIfChanged(ref _reSpecPointsInPercent, value);
        }

        public double MightInPercent
        {
            get => _mightInPercent;
            set => this.RaiseAndSetIfChanged(ref _mightInPercent, value);
        }

        public double FavorInPercent
        {
            get => _favorInPercent;
            set => this.RaiseAndSetIfChanged(ref _favorInPercent, value);
        }

        #endregion

        #region Total values

        public double TotalGainedFameInSession
        {
            get => _totalGainedFameInSessionInSession;
            set
            {
                _totalGainedFameInSessionInSession = value;
                HighestValue = GetHighestValue();
                FameInPercent = _totalGainedFameInSessionInSession / HighestValue * 100;
                this.RaiseAndSetIfChanged(ref _totalGainedFameInSessionInSession, value);
            }
        }

        public double TotalGainedSilverInSession
        {
            get => _totalGainedSilverInSessionInSession;
            set
            {
                _totalGainedSilverInSessionInSession = value;
                HighestValue = GetHighestValue();
                SilverInPercent = _totalGainedSilverInSessionInSession / HighestValue * 100;
                this.RaiseAndSetIfChanged(ref _totalGainedSilverInSessionInSession, value);
            }
        }

        public double TotalGainedReSpecPointsInSession
        {
            get => _totalGainedReSpecPointsInSessionInSession;
            set
            {
                _totalGainedReSpecPointsInSessionInSession = value;
                HighestValue = GetHighestValue();
                ReSpecPointsInPercent = _totalGainedReSpecPointsInSessionInSession / HighestValue * 100;
                this.RaiseAndSetIfChanged(ref _totalGainedReSpecPointsInSessionInSession, value);
            }
        }

        public double TotalGainedMightInSession
        {
            get => _totalGainedMightInSession;
            set
            {
                _totalGainedMightInSession = value;
                HighestValue = GetHighestValue();
                MightInPercent = _totalGainedMightInSession / HighestValue * 100;
                this.RaiseAndSetIfChanged(ref _totalGainedMightInSession, value);
            }
        }

        public double TotalGainedFavorInSession
        {
            get => _totalGainedFavorInSession;
            set
            {
                _totalGainedFavorInSession = value;
                HighestValue = GetHighestValue();
                FavorInPercent = _totalGainedFavorInSession / HighestValue * 100;
                this.RaiseAndSetIfChanged(ref _totalGainedFavorInSession, value);
            }
        }

        public double TotalSilverCostForReSpecInSession
        {
            get => _totalSilverCostForReSpecInSession;
            set => this.RaiseAndSetIfChanged(ref _totalSilverCostForReSpecInSession, value);
        }

        #endregion

        #endregion

        #region Kill / Death stats

        public int SoloKillsToday
        {
            get => _soloKillsToday;
            set => this.RaiseAndSetIfChanged(ref _soloKillsToday, value);
        }

        public int SoloKillsThisWeek
        {
            get => _soloKillsThisWeek;
            set => this.RaiseAndSetIfChanged(ref _soloKillsThisWeek, value);
        }

        public int SoloKillsThisMonth
        {
            get => _soloKillsThisMonth;
            set => this.RaiseAndSetIfChanged(ref _soloKillsThisMonth, value);
        }

        public int KillsToday
        {
            get => _killsToday;
            set => this.RaiseAndSetIfChanged(ref _killsToday, value);
        }

        public int KillsThisWeek
        {
            get => _killsThisWeek;
            set => this.RaiseAndSetIfChanged(ref _killsThisWeek, value);
        }

        public int KillsThisMonth
        {
            get => _killsThisMonth;
            set => this.RaiseAndSetIfChanged(ref _killsThisMonth, value);
        }

        public int DeathsToday
        {
            get => _deathsToday;
            set => this.RaiseAndSetIfChanged(ref _deathsToday, value);
        }

        public int DeathsThisWeek
        {
            get => _deathsThisWeek;
            set => this.RaiseAndSetIfChanged(ref _deathsThisWeek, value);
        }

        public int DeathsThisMonth
        {
            get => _deathsThisMonth;
            set => this.RaiseAndSetIfChanged(ref _deathsThisMonth, value);
        }

        public double AverageItemPowerWhenKilling
        {
            get => _averageItemPowerWhenKilling;
            set => this.RaiseAndSetIfChanged(ref _averageItemPowerWhenKilling, value);
        }

        public double AverageItemPowerOfTheKilledEnemies
        {
            get => _averageItemPowerOfTheKilledEnemies;
            set => this.RaiseAndSetIfChanged(ref _averageItemPowerOfTheKilledEnemies, value);
        }

        public double AverageItemPowerWhenDying
        {
            get => _averageItemPowerWhenDying;
            set => this.RaiseAndSetIfChanged(ref _averageItemPowerWhenDying, value);
        }

        public DateTime? LastUpdate
        {
            get => _lastUpdate;
            set => this.RaiseAndSetIfChanged(ref _lastUpdate, value);
        }

        #endregion

        #region Chest stats

        public LootedChests LootedChests
        {
            get => _lootedChests;
            set => this.RaiseAndSetIfChanged(ref _lootedChests, value);
        }

        #endregion

        public static string TranslationTitle => $"{LanguageController.Translation("DASHBOARD")}";
        public static string TranslationFame => LanguageController.Translation("FAME");
        public static string TranslationSilver => LanguageController.Translation("SILVER");
        public static string TranslationReSpec => LanguageController.Translation("RESPEC");
        public static string TranslationFaction => LanguageController.Translation("FACTION");
        public static string TranslationMight => LanguageController.Translation("MIGHT");
        public static string TranslationFavor => LanguageController.Translation("FAVOR");
        public static string TranslationResetTrackingCounter => LanguageController.Translation("RESET_TRACKING_COUNTER");
        public static string TranslationToday => LanguageController.Translation("TODAY").ToLower();
        public static string TranslationWeek => LanguageController.Translation("WEEK").ToLower();
        public static string TranslationMonth => LanguageController.Translation("MONTH").ToLower();
        public static string TranslationKills => LanguageController.Translation("KILLS");
        public static string TranslationSoloKills => LanguageController.Translation("SOLO_KILLS");
        public static string TranslationDeaths => LanguageController.Translation("DEATHS");
        public static string TranslationLastUpdate => LanguageController.Translation("LAST_UPDATE");
        public static string TranslationDataFromAlbionOnlineServers => LanguageController.Translation("DATA_FROM_ALBION_ONLINE_SERVERS");
        public static string TranslationAverageItemPowerWhenKilling => LanguageController.Translation("AVERAGE_ITEM_POWER_WHEN_KILLING");
        public static string TranslationAverageItemPowerOfTheKilledEnemies => LanguageController.Translation("AVERAGE_ITEM_POWER_OF_THE_KILLED_ENEMIES");
        public static string TranslationAverageItemPowerWhenDying => LanguageController.Translation("AVERAGE_ITEM_POWER_WHEN_DYING");
        public static string TranslationPaidSilverForReSpecThisSession => LanguageController.Translation("PAID_SILVER_FOR_RESPEC_THIS_SESSION");
        public static string TranslationPaidSilverForReSpecPerHour => LanguageController.Translation("PAID_SILVER_FOR_RESPEC_PER_HOUR");
    }
}