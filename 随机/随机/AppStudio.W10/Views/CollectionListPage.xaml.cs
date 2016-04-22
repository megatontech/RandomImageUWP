//---------------------------------------------------------------------------
//
// <copyright file="CollectionListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/21/2015 3:50:11 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Sections;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class CollectionListPage : Page
    {
        public CollectionListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, Collection1Schema>(new CollectionConfig());
            this.InitializeComponent();
        }

        public ListViewModel<LocalStorageDataConfig, Collection1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
