using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ParcelSolutionsHomePrj.Models;
using ParcelSolutionsHomePrj.Services;


namespace ParcelSolutionsHomePrj.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _logger;
        private readonly Mock<IDbService> _dbService;        
        private readonly Fixture _fixture;
                
        public HomeControllerTests()
        {
            _fixture = new Fixture();            
            _dbService = new Mock<IDbService>();
            _logger = new Mock<ILogger<HomeController>>();
                      
        }

        [TestMethod()]
        public void Get_Data_ReturnOk()
        {
            var list = _fixture.CreateMany<CustomData>(10).ToList();
            _dbService.Setup(c => c.GetCustomData()).Returns(list);

            var controller = new HomeController(_logger.Object, _dbService.Object);

            var result = controller.Index();
            var okResult = result as ViewResult;

            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Model);
            Assert.IsTrue(string.IsNullOrEmpty(okResult.ViewName) || okResult.ViewName == "Index");

        }

        [TestMethod()]
        public void Get_Data_Is_Empty()
        {            
            var controller = new HomeController(_logger.Object, _dbService.Object);

            var result = controller.Index();
            var okResult = result as ViewResult;

            Assert.IsNotNull(okResult);
            Assert.IsNull(okResult.Model);
            Assert.IsTrue(string.IsNullOrEmpty(okResult.ViewName));

        }

        [TestMethod()]
        public void Check_for_Error()
        {            
            var controller = new HomeController(_logger.Object, _dbService.Object);

            var result = controller.Error();
            var okResult = result as ViewResult;

            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Model);
            Assert.IsTrue(string.IsNullOrEmpty(okResult.ViewName));

        }
    }
}