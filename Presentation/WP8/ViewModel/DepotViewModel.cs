using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JBOB.Cards;
using WP8.BusinessLayer.Common;
using WP8.BusinessLayer.Contracts.Logic;

namespace WP8.ViewModel
{
    public class DepotViewModel : ViewModelBase
    {
        private const string PROPERTY_CARDS = "Cards";

        public DepotViewModel(IDepotLogic depotLogic)
        {
            DepotLogic = depotLogic;
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
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex, string.Empty, false);
                //TODO Update UI for error
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
    }
}
