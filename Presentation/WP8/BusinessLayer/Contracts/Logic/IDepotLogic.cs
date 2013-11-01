using System.Collections.Generic;
using JBOB.Cards;

namespace WP8.BusinessLayer.Contracts.Logic
{
    public interface IDepotLogic
    {
        List<Card> GetCards();
    }
}
