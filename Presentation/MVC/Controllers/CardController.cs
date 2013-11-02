using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using JBOB.Cards;
using JBOB.Mapper;
using Services.Interaction;

namespace Services.Controllers
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
        public Card Get(string Id)
        {
            var cardService = ServiceFactory.CreateCardService();
            var card = cardService.GetCardById(Id);

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
