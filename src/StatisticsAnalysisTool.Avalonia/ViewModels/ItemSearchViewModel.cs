using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Models.ItemSearch;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Avalonia.ViewModels
{
    public class ItemSearchViewModel : ViewModelBase
    {
        private string? _searchText;

        public ItemSearchViewModel()
        {
            _ = InitItemsAsync();
        }

        public async Task InitItemsAsync()
        {
            var isItemListLoaded = await ItemController.GetItemListFromJsonAsync().ConfigureAwait(true);
            if (!isItemListLoaded)
            {
                //SetErrorBar(Visibility.Visible, LanguageController.Translation("ITEM_LIST_CAN_NOT_BE_LOADED"));
                //GridTryToLoadTheItemListAgainVisibility = Visibility.Visible;

                //return;
            }

            Items = new ObservableCollection<ItemSearchObject>(ItemController.Items.Select(x => new ItemSearchObject()
            {
                UniqueName = x.UniqueName,
                Index = x.Index,
                LocalizationDescriptionVariable = x.LocalizationDescriptionVariable,
                LocalizationNameVariable = x.LocalizationNameVariable,
                LocalizedNames = x.LocalizedNames
            }));
        }

        #region Bindings

        [Reactive]
        public string? SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                //ItemsViewFilter();
                //ItemsView?.Refresh();
                this.RaiseAndSetIfChanged(ref _searchText, value);
            }
        }

        [Reactive]
        public bool IsTxtSearchEnabled { get; set; }

        [Reactive]
        public bool IsFilterResetEnabled { get; set; }

        [Reactive]
        public ObservableCollection<ItemSearchObject>? Items { get; set; }

        #endregion
    }
}
