using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JBOB.Serendipty;
using Services.Interaction;
using JBOB.Services;

namespace SerendiptyTestProject
{
    [TestClass]
    public class SerTest
    {
        [TestMethod]
        public void RetriveMetaDataTest()
        {
            var service = ServiceFactory.CreateSerendiptyMeta();

            var response = service.RetrieveMetaData("Apples grow on trees while Apple Macs are grown in China");
            if (string.IsNullOrEmpty(response))
            {
                Assert.Fail("No response from serpendipity");
            }
        }
    }
}
