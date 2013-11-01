using System.Collections.Generic;
using GalaSoft.MvvmLight;
using JBOB.Cards;
using WP8.BusinessLayer.Contracts.Logic;

namespace WP8.ViewModel
{
    public class DepotViewModel : ViewModelBase
    {
        private const string PROPERTY_CARDS = "Cards";

        public DepotViewModel(IDepotLogic depotLogic)
        {
            DepotLogic = depotLogic;
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
