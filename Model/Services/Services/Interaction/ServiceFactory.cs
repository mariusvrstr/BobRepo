using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBOB.Cards;
using JBOB.Users;
using Services.Services;
using Services.ServiceStubs;

namespace Services.Interaction
{
    public static class ServiceFactory
    {
        internal static bool StubUsers = false;
        internal static bool StubCards = false;


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
                return new CardServiceStub();
            }
        }


    }
}