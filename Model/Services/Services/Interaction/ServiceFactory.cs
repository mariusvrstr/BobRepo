using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBOB.Users;
using Services.Services;
using Services.ServiceStubs;

namespace Services.Interaction
{
    public static class ServiceFactory
    {
        internal static bool StubUsers = false;
        

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


    }
}