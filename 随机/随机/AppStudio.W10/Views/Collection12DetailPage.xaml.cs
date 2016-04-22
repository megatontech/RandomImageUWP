//---------------------------------------------------------------------------
//
// <copyright file="Collection12DetailPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/21/2015 3:50:11 AM</createdOn>
//
//---------------------------------------------------------------------------

using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Sections;
using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class Collection12DetailPage : Page
    {
        private DataTransferManager _dataTransferManager;

        public Collection12DetailPage()
        {
            this.ViewModel = new DetailViewModel<DynamicStorageDataConfig, Collection121Schema>(new Collection12Config());

            this.InitializeComponent();
        }

        public DetailViewModel<DynamicStorageDataConfig, Collection121Schema> ViewModel { get; set; }        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync(e.Parameter as ItemViewModel);

            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AppBarButton button = sender as AppBarButton;
            int newFontSize = Int32.Parse(button.Tag.ToString());
            mainPanel.BodyFontSize = newFontSize;
            mainPanel.UpdateFontSize();
        }
    }
}
