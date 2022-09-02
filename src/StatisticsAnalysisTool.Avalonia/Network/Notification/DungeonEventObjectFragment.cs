using ReactiveUI;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using System;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Network.Notification
{
    public class DungeonEventObjectFragment : ReactiveObject
    {
        private int _id;
        private bool _isBossChest;
        private bool _isChestOpen;
        private DateTime _opened;
        private TreasureRarity _rarity;
        private ChestStatus _status;
        private DungeonEventObjectType _type;
        private string? _uniqueName;
        private ShrineType _shrineType;
        private ShrineBuff _shrineBuff;

        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public DateTime Opened
        {
            get => _opened;
            set => this.RaiseAndSetIfChanged(ref _opened, value);
        }

        public string? UniqueName
        {
            get => _uniqueName;
            set => this.RaiseAndSetIfChanged(ref _uniqueName, value);
        }

        public DungeonEventObjectType Type
        {
            get => _type;
            set => this.RaiseAndSetIfChanged(ref _type, value);
        }

        public TreasureRarity Rarity
        {
            get => _rarity;
            set
            {
                _rarity = value;
                Status = SetStatus();
                this.RaiseAndSetIfChanged(ref _rarity, value);
            }
        }

        public ChestStatus Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);
        }

        public ShrineType ShrineType
        {
            get => _shrineType;
            set => this.RaiseAndSetIfChanged(ref _shrineType, value);
        }

        public ShrineBuff ShrineBuff
        {
            get => _shrineBuff;
            set => this.RaiseAndSetIfChanged(ref _shrineBuff, value);
        }

        public bool IsBossChest
        {
            get => _isBossChest;
            set => this.RaiseAndSetIfChanged(ref _isBossChest, value);
        }

        public bool IsChestOpen
        {
            get => _isChestOpen;
            set
            {
                _isChestOpen = value;
                Status = SetStatus();
                this.RaiseAndSetIfChanged(ref _isChestOpen, value);
            }
        }

        public string Hash => $"{Id}{UniqueName}";

        [JsonIgnore]
        public static string TranslationStandard => LanguageController.Translation("STANDARD");

        [JsonIgnore]
        public static string TranslationUncommon => LanguageController.Translation("UNCOMMON");

        [JsonIgnore]
        public static string TranslationRare => LanguageController.Translation("RARE");

        [JsonIgnore]
        public static string TranslationLegendary => LanguageController.Translation("LEGENDARY");

        [JsonIgnore]
        public static string TranslationBossChest => LanguageController.Translation("BOSS_CHEST");

        [JsonIgnore]
        public static string TranslationBookChest => LanguageController.Translation("BOOK_CHEST");

        [JsonIgnore]
        public static string TranslationCombatBuff => LanguageController.Translation("COMBAT_BUFF");

        [JsonIgnore]
        public static string TranslationSilverShrine => LanguageController.Translation("SILVER_SHRINE");

        [JsonIgnore]
        public static string TranslationFameShrine => LanguageController.Translation("FAME_SHRINE");

        private ChestStatus SetStatus()
        {
            if (IsChestOpen)
            {
                switch (Rarity)
                {
                    case TreasureRarity.Standard:
                        return ChestStatus.StandardChestOpen;
                    case TreasureRarity.Uncommon:
                        return ChestStatus.UncommonChestOpen;
                    case TreasureRarity.Rare:
                        return ChestStatus.RareChestOpen;
                    case TreasureRarity.Legendary:
                        return ChestStatus.LegendaryChestOpen;
                }
            }
            else
            {
                switch (Rarity)
                {
                    case TreasureRarity.Standard:
                        return ChestStatus.StandardChestClose;
                    case TreasureRarity.Uncommon:
                        return ChestStatus.UncommonChestClose;
                    case TreasureRarity.Rare:
                        return ChestStatus.RareChestClose;
                    case TreasureRarity.Legendary:
                        return ChestStatus.LegendaryChestClose;
                }
            }

            return ChestStatus.Unknown;
        }
    }
}