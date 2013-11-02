using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBOB.Cards;
using JBOB.Serendipty;
using JBOB.Users;
using JBOB.Services;
using JBOB.Services.Services;

namespace Services.Interaction
{
    public static class ServiceFactory
    {

        public static IUserService CreateUserService()
        {
             return new UserService();
        }

        public static ICardService CreateCardService()
        {
            return new CardService();
        }

        public static ISerendiptyMeta CreateSerendiptyMeta()
        {
            return new SerendiptyMeta();
        }

    }
}