using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using ParcelSolutionsHomePrj.Data;
using ParcelSolutionsHomePrj.Models;
using ParcelSolutionsHomePrj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelSolutionsHomePrj.Services.Tests
{
    [TestClass()]
    public class DbServiceTests
    {
        private readonly Mock<ILogger<DbService>> _logger;
        private readonly Mock<IDataRepository> _repo;
        private readonly Fixture _fixture;


        public DbServiceTests()
        {
            _fixture = new Fixture();
            _repo = new Mock<IDataRepository>();
            _logger = new Mock<ILogger<DbService>>();
        }

        [TestMethod()]
        public void Get_data_from_Repo()
        {
            var list = _fixture.CreateMany<CustomData>(10).ToList();

            _repo.Setup(r => r.GetDataResult()).Returns(list);

            var service = new DbService(_repo.Object, _logger.Object);

            var result = service.GetCustomData();

            Assert.IsNotNull(result);            
        }

        [TestMethod()]
        public void Get_empty_data_from_Repo()
        {            
            _repo.Setup(r => r.GetDataResult()).Returns([]);

            var service = new DbService(_repo.Object, _logger.Object);

            var result = service.GetCustomData();

            Assert.AreEqual(0, result.Count);
        }
    }
}