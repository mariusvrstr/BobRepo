using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBOB.Cards
{
    public interface ICardService
    {
        Card AddCard(Card card);
        IEnumerable<Card> GetAllCards();
        Card GetCardById(string id);
        bool UpdateCard(Card card);

    }
}
