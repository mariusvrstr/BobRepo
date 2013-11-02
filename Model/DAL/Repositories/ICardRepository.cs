using System.Linq;
using JBOB.Database.Entities;

namespace JBOB.Repositories
{
    public interface ICardRepository
    {
        Card AddCard(Card card);
        IQueryable<Card> GetAllCards();
        void DeleteAllCards();
        Card GetCardById(int Id);
        bool UpdateCard(Card card);
    }
}
