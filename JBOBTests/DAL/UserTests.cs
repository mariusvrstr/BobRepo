using System;
using System.Collections.Generic;
using System.Diagnostics;
using JBOB.Entities;
using JBOB.Interaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JBOB;

namespace JBOBTests.DAL
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserAddTest()
        {
            var context = DataContextFactory.CreateContext();

            var user = new User
            {
                Name = "Bob",
                Surname = "Chino",
                Login = "bob",
                Password = "bob123",
                Roles = new List<Role>
                {
                    Role.Admin,
                    Role.HR
                }
            };

           var contextUser = context.UserRepository.AddUser(user);

           context.SaveChanges();

           Assert.AreEqual(user.Name, contextUser.Name);

        }
    }
}
