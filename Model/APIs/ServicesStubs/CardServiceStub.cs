﻿using System.Collections.Generic;
using JBOB.Cards;
using JBOB.Mapper;
using JBOB.TestData;

namespace JBOB.API.ServicesStubs
{
    public class CardServiceStub : ICardService
    {

        public Card AddCard(Card card)
        {
            return card;
        }

        public IEnumerable<Card> GetAllCards()
        {
            var users = new List<Card>
            {
                ObjectMother.Cards.Mandela.Map(),
                ObjectMother.Cards.Spca.Map(),
                ObjectMother.Cards.WalkTheTalk.Map()
            };

            return users;
        }

        public Card GetCardById(int id)
        {
            var card = ObjectMother.Cards.Mandela.Map();
            return card;
        }

        public bool UpdateCard(Card card)
        {
            return true;
        }
    }
}