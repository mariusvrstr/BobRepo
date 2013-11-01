using System.Linq;
using JBOB.Entities;
using JBOB.Repositories;

// ReSharper disable CheckNamespace
namespace JBOB
// ReSharper restore CheckNamespace
{
    internal partial class DataContext : ICardRepository
    {
        public Card AddCard(Card card)
        {
            var contextCard = this.Cards.Add(card);

            return contextCard;
        }

        public IQueryable<Card> GetAllCards()
        {
            return Queryable.Select<Card, Card>(this.Cards, thisCard => thisCard);
        }
    }
}
