
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JBOB.Interaction;
using JBOB.Users;
using User = JBOB.Entities.User;

namespace JBOBTests.TestData
{
    internal static partial class ObjectMother
    {
        internal static class Users
        {
            public static User Fred { get; set; }
            public static User Chow { get; set; }


            public static void Initialize()
            {
                var context = DataContextFactory.CreateContext();

                Fred = context.UserRepository.AddUser(new User {Login = "Fred", Name = "Fred", Password = "fred123", Roles = new List<UserRoleEnum> {UserRoleEnum.Admin}, Surname = "Deer", Id = "0503859374688"});
                Chow = context.UserRepository.AddUser(new User { Login = "Chow", Name = "Chow", Password = "cs123", Roles = new List<UserRoleEnum> { UserRoleEnum.HR }, Surname = "Mein", Id = "0503759344688" });

                context.SaveChanges();
            }
        }
    }
}
