using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.BusinessLayer.Contracts.Gateway;
using JBOB.Cards;
using System.Net;
using WP8.BusinessLayer.Common;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.IO;

namespace WP8.BusinessLayer.Implementation.Gateway
{
    public class CardGateway : ICardGateway
    {
        public List<Card> GetCards()
        {
            List<Card> cards = CustomWebRequest.WebRequestGet<List<Card>>("/api/card");
            cards.Sort((card1, card2) => card2.CardId.CompareTo(card1.CardId));
            return cards;
        }
    }
}
