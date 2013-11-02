using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JBOB.Cards;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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
        private const string PROPERTY_SELECTED_CARD = "SelectedCard";

        public DepotViewModel(IDepotLogic depotLogic)
        {
            DepotLogic = depotLogic;
            IsProgressIndicatorVisible = Visibility.Visible;
            Information = AppResources.Loading;
            IsInformationVisible =  Visibility.Visible;
            LoadedCommand = new RelayCommand(() => OnLoaded());
        }

        private void GoToCardView(Card card)
        {
            PhoneApplicationService.Current.State[Constants.CARD_SELECTED_APPLICATIONSERVICE_SETTING] = card;
            Navigate.ToPage(Constants.URL_CARD_VIEW);
        }

        public ICommand LoadedCommand
        {
            get;
            private set;
        }

        private Card selectedCard;
        public Card SelectedCard
        {
            get
            {
                return selectedCard;
            }
            set
            {
                if (value == null || selectedCard == value)
                {
                    return;
                }
                selectedCard = value;
                GoToCardView(selectedCard);
                RaisePropertyChanged(PROPERTY_SELECTED_CARD);
            }
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
