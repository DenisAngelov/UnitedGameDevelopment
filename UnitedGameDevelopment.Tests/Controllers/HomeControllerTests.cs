
namespace UnitedGameDevelopment.Tests.Controllers
{
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class HomeControllerTests
    {

        private HomeController controller;

        [TestInitialize]
        public void Setup()
        {
            this.controller = new HomeController();
        }

        [TestMethod]
        public void Index_ShouldRenderDefaultView()
        {
            this.controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
