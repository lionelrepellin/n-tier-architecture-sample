using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using WebProject.Business.Services;
using WebProject.Controllers;

namespace WebProject.Tests.Controllers
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
