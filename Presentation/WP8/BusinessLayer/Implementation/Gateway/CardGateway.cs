using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.BusinessLayer.Contracts.Gateway;
using JBOB.Cards;
using System.Net;
using WP8.BusinessLayer.Common;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.IO;

namespace WP8.BusinessLayer.Implementation.Gateway
{
    public class CardGateway : ICardGateway
    {
        

        public List<Card> GetCards()
        {
            //TODO: Remove, just for testing
            /*List<Card> cards = new List<Card>();
            cards.Add(new Card { Id = "543321", Name = "Nelson Mandela 46664", Description = "Do something for the Nelson Mandela 46664 initiative. 67 minutes - that's all it takes.", Category = CardCategoryEnum.Elderly, ActivityOptions = new List<ActivityTypeEnum> { ActivityTypeEnum.OnceOff }, Weight = 100 });
            cards.Add(new Card { Id = "543325", Name = "702 Walk The Talk", Description = "Do a 5 or 10 kilometer fun run. It's all for charity!", Category = CardCategoryEnum.Healthcare, ActivityOptions = new List<ActivityTypeEnum> { ActivityTypeEnum.OnceOff }, Weight = 50 });
            cards.Add(new Card { Id = "662255", Name = "SPCA Walk a dog", Description = "Walk a dog, just for fun. Do it for an hour and earn the points.", Category = CardCategoryEnum.Animals, ActivityOptions = new List<ActivityTypeEnum> { ActivityTypeEnum.FreeOccuring }, Weight = 20 });
            return cards;*/
            return CustomWebRequest.WebRequestGet<List<Card>>("/api/card");
        }
    }
}
