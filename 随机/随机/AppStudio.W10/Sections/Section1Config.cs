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
    public class Section1Config : SectionConfigBase<DynamicStorageDataConfig, Section1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, Section1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<Section1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=5f1684d4-1f91-4cc3-897b-47162f82b4b3&appId=d47a0b4b-9ecd-4c9a-99c2-2d5e5b5d08b7"),
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
                return NavigationInfo.FromPage("Section1ListPage");
            }
        }

        public override ListPageConfig<Section1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Section1Schema>
                {
                    Title = "历史",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = "";
                        viewModel.SubTitle = "";
                        viewModel.Description = "";
                        viewModel.Image = "";
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("Section1DetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Section1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Section1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = "";
                    viewModel.Description = "";
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<Section1Schema>>
                {
                };

                return new DetailPageConfig<Section1Schema>
                {
                    Title = "历史",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "历史"; }
        }
    }
}
