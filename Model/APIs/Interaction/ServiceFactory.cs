using JBOB.API.Services;
using JBOB.API.ServicesStubs;
using JBOB.Cards;
using JBOB.Serendipty;
using JBOB.Services;
using JBOB.Users;

namespace JBOB.API.Interaction
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