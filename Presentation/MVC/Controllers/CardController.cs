using System.Collections.Generic;
using System.Web.Http;
using JBOB.Cards;
using Services.Interaction;

namespace JBOB.Controllers
{
    public class CardController : ApiController
    {
        // GET api/card
        public IEnumerable<Card> Get()
        {
            var cardService = ServiceFactory.CreateCardService();
            var cards = cardService.GetAllCards();

            return cards;
        }

        // GET api/card/5
        public Card Get(int id)
        {
            var cardService = ServiceFactory.CreateCardService();
            var card = cardService.GetCardById(id);

            return card;
        }

        // POST api/card
        public Card Add([FromBody]Card card)
        {
            var cardService = ServiceFactory.CreateCardService();
            var addedCard = cardService.AddCard(card);

            return addedCard;

        }

        // PUT api/card/5
        public void Update(int id, [FromBody]Card user)
        {
        }

        // DELETE api/card/5
        public void Delete(int id)
        {
        }

    }
}
