//---------------------------------------------------------------------------
//
// <copyright file="MenuListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/21/2015 3:50:11 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using AppStudio.Sections;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class MenuListPage : Page
    {
        public MenuListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new MenuConfig());
            this.InitializeComponent();
        }

        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
