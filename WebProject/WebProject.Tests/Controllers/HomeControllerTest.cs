using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestProject.Business.Services;
using TestProject.Controllers;

namespace TestProject.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private Mock<ICustomerAndAddressService> _customerAndAddressServiceMock;

        [SetUp]
        public void BeforeEach()
        {
            _customerAndAddressServiceMock = new Mock<ICustomerAndAddressService>();
        }


        [Test]
        public void Index_CustomerAndAddressServiceIsCalled()
        {
            HomeController controller = new HomeController(_customerAndAddressServiceMock.Object);

            controller.Index();

            _customerAndAddressServiceMock.Verify(m => m.FindAll(), Times.Once);
        }
    }
}
