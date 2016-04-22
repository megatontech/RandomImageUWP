//---------------------------------------------------------------------------
//
// <copyright file="Collection12ListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/21/2015 3:50:11 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Sections;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class Collection12ListPage : Page
    {
        public Collection12ListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, Collection121Schema>(new Collection12Config());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, Collection121Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
