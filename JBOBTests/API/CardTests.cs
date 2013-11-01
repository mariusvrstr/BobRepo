﻿using System;
using System.Collections.Generic;
using JBOB.TestData;
using JBOB.Users;
using JBOB.Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Controllers;
using TestData;

namespace JBOBTests.API
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardAddApiTest()
        {
            var controller = new CardController();
            
            var card = new Card
            {
                Category = CardCategoryEnum.Healthcare,
                Description = "Work at a nursery home for the eldery",
                Name = "Outehuise WeltevredenPark",
                Weight = 10,
                ActivityOptions = new List<ActivityTypeEnum>
                {
                    ActivityTypeEnum.OnceOff
                }
            };

            controller.Add(card);
        }


    }
}
