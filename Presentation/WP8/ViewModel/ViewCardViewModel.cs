using GalaSoft.MvvmLight;
using JBOB.Cards;
using Microsoft.Phone.Shell;
using WP8.BusinessLayer.Common;

namespace WP8.ViewModel
{
    public class ViewCardViewModel : ViewModelBase
    {
        private const string PROPERTY_CARDS = "Cards";

        public ViewCardViewModel()
        {
            Card = PhoneApplicationService.Current.State[Constants.CARD_SELECTED_APPLICATIONSERVICE_SETTING] as Card;
        }

        private Card card;
        public Card Card
        {
            get 
            { 
                return card; 
            }
            set
            {
                card = value;
                RaisePropertyChanged(PROPERTY_CARDS);
            }
        }
    }
}
