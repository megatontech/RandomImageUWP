using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Uwp.Navigation;
using AppStudio.Config;
using AppStudio.ViewModels;

namespace AppStudio.Sections
{
    public class CollectionConfig : SectionConfigBase<LocalStorageDataConfig, Collection1Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, Collection1Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<Collection1Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Collection.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("CollectionListPage");
            }
        }

        public override ListPageConfig<Collection1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Collection1Schema>
                {
                    Title = "Collection",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = "";
                        viewModel.SubTitle = "";
                        viewModel.Description = "";
                        viewModel.Image = "";
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("CollectionDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Collection1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Collection1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = "";
                    viewModel.Description = "";
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<Collection1Schema>>
                {
                };

                return new DetailPageConfig<Collection1Schema>
                {
                    Title = "Collection",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Collection"; }
        }
    }
}
