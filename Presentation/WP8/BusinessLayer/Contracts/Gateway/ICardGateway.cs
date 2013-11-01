using System.Collections.Generic;
using JBOB.Cards;

namespace WP8.BusinessLayer.Contracts.Gateway
{
    public interface ICardGateway
    {
        List<Card> GetCards();
    }
}
