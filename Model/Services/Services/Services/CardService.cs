
namespace Services.Services
{
    using System.Collections.Generic;
    using JBOB.Cards;
    using JBOB.Interaction;
    using JBOB.Mapper;

    public class CardService : ICardService
    {

        public Card AddCard(Card card)
        {
            var context = DataContextFactory.CreateContext();
            var addedCard = context.CardRepository.AddCard(card.Map());
            context.SaveChanges();

            return addedCard.Map();
        }

        public IEnumerable<Card> GetAllCards()
        {
            var context = DataContextFactory.CreateContext();
            var cards = context.CardRepository.GetAllCards();

            var mappedCards = new List<Card>();

            foreach (var card in cards)
            {
                mappedCards.Add(card.Map());
            }

            return mappedCards;
        }
    }
}