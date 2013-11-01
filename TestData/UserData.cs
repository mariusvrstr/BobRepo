using System.Collections.Generic;
using JBOB.Interaction;
using JBOB.Users;
using User = JBOB.Database.Entities.User;

namespace JBOB.TestData
{
    public static partial class ObjectMother
    {
        public static class Users
        {
            public static User Fred { get; set; }
            public static User Chow { get; set; }
            public static User Peter { get; set; }
            public static User John { get; set; }


            public static void Initialize()
            {
                var context = DataContextFactory.CreateContext();

                Fred = context.UserRepository.AddUser(new User {Login = "Fred", Name = "Fred", Password = "fred123", Roles = new List<UserRoleEnum> {UserRoleEnum.Admin}, Surname = "Deer", Id = "0503859374688"});
                Chow = context.UserRepository.AddUser(new User { Login = "Chow", Name = "Chow", Password = "cs123", Roles = new List<UserRoleEnum> { UserRoleEnum.HR }, Surname = "Mein", Id = "0503759344688" });
                Peter = context.UserRepository.AddUser(new User { Login = "Peter", Name = "Peter", Password = "peter123", Roles = new List<UserRoleEnum> { UserRoleEnum.HR }, Surname = "Slone", Id = "0534545454688" });
                John = context.UserRepository.AddUser(new User { Login = "John", Name = "John", Password = "john123", Roles = new List<UserRoleEnum> { UserRoleEnum.HR }, Surname = "Doe", Id = "0503759334545" });

                context.SaveChanges();
            }

            public static void Clear()
            {
                var context = DataContextFactory.CreateContext();

                context.UserRepository.DeleteAllUsers();

                context.SaveChanges();
            }
        }
    }
}
