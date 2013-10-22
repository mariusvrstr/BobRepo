using System;
using System.Collections.Generic;
using JBOB.TestData;
using JBOB.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Controllers;
using Services.Interaction;
using TestData;

namespace JBOBTests.Services
{
    [TestClass]
    public class UserTests
    {
        [TestInitialize]
        public void TestInitialization()
        {
            Wado.ClearDatabase();
            ObjectMother.Initialize();
        }
        
        [TestMethod]
        public void UserAddServiceTest()
        {
            var service = ServiceFactory.CreateUserService();

            var user = new User
            {
                Name = "Bob",
                Surname = "Chino",
                Login = "bob",
                Password = "bob123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                }
            };

            service.AddUser(user);
            Console.WriteLine(user.ToString());
        }
    }
}
