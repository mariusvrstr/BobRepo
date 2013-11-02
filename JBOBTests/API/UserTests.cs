using System;
using System.Collections.Generic;
using JBOB.TestData;
using JBOB.Users;
using JBOB.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestData;

namespace JBOBTests.API
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
        public void UserAddApiTest()
        {
            var controller = new UserController();

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

            controller.Add(user);
            Console.WriteLine(user.ToString());
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            var controller = new UserController();

            var users = controller.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
