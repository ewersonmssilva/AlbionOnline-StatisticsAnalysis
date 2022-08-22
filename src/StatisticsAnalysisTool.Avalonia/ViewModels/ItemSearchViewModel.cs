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
        public ObservableCollection<ItemSearchObject>? Items { get; set; }

        #endregion
    }
}
