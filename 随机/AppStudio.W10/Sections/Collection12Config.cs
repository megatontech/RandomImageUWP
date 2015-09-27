using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using Windows.Storage;
using AppStudio.Config;
using AppStudio.ViewModels;

namespace AppStudio.Sections
{
    public class Collection12Config : SectionConfigBase<DynamicStorageDataConfig, Collection121Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, Collection121Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<Collection121Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=3d4cbc13-e811-4816-84de-a21adbed157d&appId=d47a0b4b-9ecd-4c9a-99c2-2d5e5b5d08b7"),
                    AppId = "d47a0b4b-9ecd-4c9a-99c2-2d5e5b5d08b7",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("Collection12ListPage");
            }
        }

        public override ListPageConfig<Collection121Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Collection121Schema>
                {
                    Title = "Collection12",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = "";
                        viewModel.SubTitle = "";
                        viewModel.Description = "";
                        viewModel.Image = "";
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("Collection12DetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Collection121Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Collection121Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = "";
                    viewModel.Description = "";
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<Collection121Schema>>
                {
                };

                return new DetailPageConfig<Collection121Schema>
                {
                    Title = "Collection12",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Collection12"; }
        }
    }
}
