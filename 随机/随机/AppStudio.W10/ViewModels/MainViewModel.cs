using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using AppStudio.DataProviders;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Sections;


namespace AppStudio.ViewModels
{
    public class MainViewModel : PageViewModel
    {
        public MainViewModel(int visibleItems) : base()
        {
            PageTitle = "随机";
            Section1 = new ListViewModel<DynamicStorageDataConfig, Section1Schema>(new Section1Config(), visibleItems);
            Html = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new HtmlConfig(), visibleItems);
            Menu = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new MenuConfig());
            Collection = new ListViewModel<LocalStorageDataConfig, Collection1Schema>(new CollectionConfig(), visibleItems);
            Collection12 = new ListViewModel<DynamicStorageDataConfig, Collection121Schema>(new Collection12Config(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<DynamicStorageDataConfig, Section1Schema> Section1 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Html { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Menu { get; private set; }
        public ListViewModel<LocalStorageDataConfig, Collection1Schema> Collection { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, Collection121Schema> Collection12 { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

		public override void UpdateCommonProperties(SplitViewDisplayMode splitViewDisplayMode)
        {
            base.UpdateCommonProperties(splitViewDisplayMode);
            if (splitViewDisplayMode == SplitViewDisplayMode.Overlay)
            {
                AppBarRow = 3;
                AppBarColumn = 0;
                AppBarColumnSpan = 2;
            }
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Section1;
            yield return Html;
            yield return Menu;
            yield return Collection;
            yield return Collection12;
        }
    }
}
