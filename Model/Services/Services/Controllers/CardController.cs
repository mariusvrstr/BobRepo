using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using JBOB.Cards;
using Services.Interaction;

namespace Services.Controllers
{
    public class CardController : ApiController
    {
        // GET api/card
        public IEnumerable<Card> Get()
        {
            var userService = ServiceFactory.CreateCardService();
            var users = userService.GetAllCards();

            return users;
        }

    }
}
