using System.Collections.Generic;
using JBOB.Users;
using JBOBTests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Controllers;

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

            // Use Service to save

            // Assert.AreEqual(user.Name, contextUser.Name);

        }
    }
}
