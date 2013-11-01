using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.BusinessLayer.Contracts.Gateway;
using WP8.BusinessLayer.Contracts.Logic;
using JBOB.Cards;

namespace WP8.BusinessLayer.Implementation.Logic
{
    public class DepotLogic : IDepotLogic
    {
        private readonly ICardGateway cardGateway;

        public DepotLogic(ICardGateway cardGateway) {
            this.cardGateway = cardGateway;
        }

        public List<Card> GetCards()
        {
            return cardGateway.GetCards();
        }
    }
}
