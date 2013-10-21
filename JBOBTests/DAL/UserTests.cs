using System;
using System.Collections.Generic;
using JBOB.Interaction;
using JBOB.Users;
using JBOBTests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User = JBOB.Entities.User;

namespace JBOBTests.DAL
{
    [TestClass]
    public class UserDataAccessTest
    {
        [TestInitialize]
        public void TestInitialization()
        {
            Wado.ClearDatabase();
            ObjectMother.Initialize();
        }

        [TestMethod]
        public void UserAddRepoTest()
        {
            var context = DataContextFactory.CreateContext();

            var user = new User
            {
                Name = "Sandra",
                Surname = "Johnson",
                Login = "sandra",
                Password = "sandra112233",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                }
            };

            var addedUser = context.UserRepository.AddUser(user);
            context.SaveChanges();

            Assert.AreEqual(user.Name, addedUser.Name);

        }
    }
}
