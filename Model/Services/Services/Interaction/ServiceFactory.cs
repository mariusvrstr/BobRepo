using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBOB.Cards;
using JBOB.Serendipty;
using JBOB.Users;
using JBOB.Services;
using Services.ServiceStubs;
using JBOB.Services.Services;

namespace Services.Interaction
{
    public static class ServiceFactory
    {
        internal static bool StubUsers = false;
        internal static bool StubCards = false;
        internal static bool StubSerendipity = false;


        public static IUserService CreateUserService()
        {
            if (StubUsers)
            {
                return new UserServiceStub();
            }
            else
            {
                 return new UserService();
            }
        }

        public static ICardService CreateCardService()
        {
            if (StubCards)
            {
                return new CardServiceStub();
            }
            else
            {
                return new CardService();
            }
        }

        public static ISerendiptyMeta CreateSerendiptyMeta()
        {
            if (StubSerendipity)
            {
                return new SerendiptyMeta();
            }
            else
            {
                return new SerendiptyMeta();
            }
        }


    }
}