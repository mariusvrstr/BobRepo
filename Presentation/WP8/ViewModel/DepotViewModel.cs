using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JBOB.Cards;
using WP8.BusinessLayer.Common;
using WP8.BusinessLayer.Contracts.Logic;
using WP8.Resources;

namespace WP8.ViewModel
{
    public class DepotViewModel : ViewModelBase
    {
        private const string PROPERTY_CARDS = "Cards";
        private const string PROPERTY_IS_PROGRESS_VISIBLE = "IsProgressIndicatorVisible";
        private const string PROPERTY_INFORMATION = "Information";
        private const string PROPERTY_IS_INFORMATION_VISIBLE = "IsInformationVisible";

        public DepotViewModel(IDepotLogic depotLogic)
        {
            DepotLogic = depotLogic;
            IsProgressIndicatorVisible = Visibility.Visible;
            Information = AppResources.Loading;
            IsInformationVisible =  Visibility.Visible;
            LoadedCommand = new RelayCommand(() => OnLoaded());
        }

        public ICommand LoadedCommand
        {
            get;
            private set;
        }

        private void OnLoaded()
        {
            doGetCards();
        }

        private async void doGetCards()
        {
            try
            {
                Cards = await Task.Run(() => DepotLogic.GetCards());
                IsProgressIndicatorVisible = Visibility.Collapsed;
                Information = string.Empty;
                IsInformationVisible = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, string.Empty, false);
                IsProgressIndicatorVisible = Visibility.Collapsed;
                Information = AppResources.Wrong;
            }
        }

        public IDepotLogic DepotLogic { get; private set; }

        private List<Card> cards;
        public List<Card> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                RaisePropertyChanged(PROPERTY_CARDS);
            }
        }

        private Visibility isProgressIndicatorVisible;
        public Visibility IsProgressIndicatorVisible
        {
            get
            {
                return isProgressIndicatorVisible;
            }
            set
            {
                isProgressIndicatorVisible = value;
                RaisePropertyChanged(PROPERTY_IS_PROGRESS_VISIBLE);
            }
        }

        private string information;
        public string Information
        {
            get
            {
                return information;
            }
            set
            {
                information = value;
                RaisePropertyChanged(PROPERTY_INFORMATION);
            }
        }

        private Visibility isInformationVisible;
        public Visibility IsInformationVisible
        {
            get
            {
                return isInformationVisible;
            }
            set
            {
                isInformationVisible = value;
                RaisePropertyChanged(PROPERTY_IS_INFORMATION_VISIBLE);
            }
        }
    }
}
