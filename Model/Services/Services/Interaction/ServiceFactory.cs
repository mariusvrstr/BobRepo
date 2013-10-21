using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBOB.Users;
using Services.Services;

namespace Services.Interaction
{
    public static class ServiceFactory
    {
        public static IUserService CreateUserService()
        {
            return new UserService();
        }


    }
}