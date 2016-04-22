//---------------------------------------------------------------------------
//
// <copyright file="Section1ListPage.xaml.cs" company="Microsoft">
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
    public sealed partial class Section1ListPage : Page
    {
        public Section1ListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, Section1Schema>(new Section1Config());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, Section1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
