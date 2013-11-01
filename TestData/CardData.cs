using System.Collections.Generic;
using JBOB.Cards;
using JBOB.Interaction;
using Card = JBOB.Database.Entities.Card;

namespace JBOB.TestData
{
    public static partial class ObjectMother
    {
        public static class Cards
        {
            public static Card Mandela { get; set; }
            public static Card WalkTheTalk { get; set; }
            public static Card Spca { get; set; }


            public static void Initialize()
            {
                var context = DataContextFactory.CreateContext();

                Mandela = context.CardRepository.AddCard(new Card { Id = "543321", Name = "Nelson Mandela 46664", Description = "Do something for the Nelson Mandela 46664 initiative. 67 minutes - that's all it takes.",  Weight = 100 });
                WalkTheTalk = context.CardRepository.AddCard(new Card { Id = "543325", Name = "702 Walk The Talk", Description = "Do a 5 or 10 kilometer fun run. It's all for charity!", Weight = 50 });
                Spca = context.CardRepository.AddCard(new Card { Id = "662255", Name = "SPCA Walk a dog", Description = "Walk a dog, just for fun. Do it for an hour and earn the points.", Weight = 20 });

                context.SaveChanges();
            }

            public static void Clear()
            {
                var context = DataContextFactory.CreateContext();

                context.CardRepository.DeleteAllCards();

                context.SaveChanges();
            }
        }
    }
}
