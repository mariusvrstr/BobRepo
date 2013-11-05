using System.Collections.Generic;
using System.Web.Http;
using JBOB.API.Interaction;
using JBOB.Cards;

namespace JBOB.API.Controllers
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

       /* // PUT api/card/5
        public void Update([FromBody]Card user, int id = 0)
        {
        } */

        // DELETE api/card/5
        public void Delete(int id)
        {
        }

    }
}
