using System.Linq;
using JBOB.Entities;

namespace JBOB.Repositories
{
    public interface ICardRepository
    {
        Card AddCard(Card card);
        IQueryable<Card> GetAllCards();
        void DeleteAllCards();
    }
}
