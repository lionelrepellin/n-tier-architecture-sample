using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebProject;
using WebProject.Controllers;

namespace WebProject.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Réorganiser
            ValuesController controller = new ValuesController();

            // Agir
            IEnumerable<string> result = controller.Get();

            // Déclarer
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Réorganiser
            ValuesController controller = new ValuesController();

            // Agir
            string result = controller.Get(5);

            // Déclarer
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Réorganiser
            ValuesController controller = new ValuesController();

            // Agir
            controller.Post("value");

            // Déclarer
        }

        [TestMethod]
        public void Put()
        {
            // Réorganiser
            ValuesController controller = new ValuesController();

            // Agir
            controller.Put(5, "value");

            // Déclarer
        }

        [TestMethod]
        public void Delete()
        {
            // Réorganiser
            ValuesController controller = new ValuesController();

            // Agir
            controller.Delete(5);

            // Déclarer
        }
    }
}
