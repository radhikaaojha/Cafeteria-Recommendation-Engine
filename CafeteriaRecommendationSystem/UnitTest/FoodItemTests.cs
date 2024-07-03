using AutoMapper;
using CMS.Data.Profiles;
using CMS.Data.Repository;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services;
using CMS.Data.Services.Interfaces;
using Common.Enums;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class FoodItemServiceTests
    {
        private FoodItemService _foodItemService;
        private CMSDbContext _context;
        private Mock<IAppActivityLogRepository> _mockAppActivityLogRepository;
        private Mock<INotificationService> _mockNotificationService;
        private IMapper _mapper;
        private ILogger<FoodItemService> _logger;
        [TestInitialize]
        public void TestInitialize()
        {

            DbContextOptions<CMSDbContext> dbOptions = new DbContextOptionsBuilder<CMSDbContext>().UseInMemoryDatabase(databaseName: "CafeteriaManagementSystem").Options;
            _context = new CMSDbContext(dbOptions);
            _mockAppActivityLogRepository = new Mock<IAppActivityLogRepository>();
            _mockNotificationService = new Mock<INotificationService>();
            _logger = Mock.Of<ILogger<FoodItemService>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new FoodItemProfile()));
            _mapper = config.CreateMapper();

            _foodItemService = new FoodItemService(
                new FoodItemRepository(_context),
                new CrudBaseRepository<FoodItem>(_context),
                _mapper,
                _logger,
                _mockAppActivityLogRepository.Object,
                _mockNotificationService.Object);
        }

        [TestMethod]
        public async Task UpdateStatus_Should_Update_Status_And_Return_FoodItem()
        {
            // Arrange
            var foodItemId = 1;
            var newStatusId = (int)Status.Removed;

            var foodItem = new FoodItem { Id = foodItemId, Name = "Test Food for Update Status ", StatusId = (int)Status.Available };
            _context.FoodItem.Add(foodItem);
            _context.SaveChanges();
            // Act
            var result = await _foodItemService.UpdateStatus(foodItemId, newStatusId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(foodItemId, result.Id);
            Assert.AreEqual(newStatusId, result.StatusId);
        }

        [TestMethod]
        public async Task UpdatePrice_Should_Update_Price_And_Return_FoodItem()
        {
            // Arrange
            var newPrice = 9.99m;

            var foodItem = new FoodItem { Name = "Test Food for Update Price", Price = 5.00m, StatusId = (int)Status.Available };
            _context.FoodItem.Add(foodItem);
            _context.SaveChanges();

            // Act
            var result = await _foodItemService.UpdatePrice(foodItem.Id, newPrice);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(foodItem.Id, result.Id);
            Assert.AreEqual(newPrice, result.Price);
        }

        [TestMethod]
        public async Task DoesFoodItemWithSameNameExists_Should_Return_False_When_FoodItem_Does_Not_Exist()
        {
            // Arrange
            var foodItemName = "Unique Item Name";

            // Act
            var result = await _foodItemService.DoesFoodItemWithSameNameExists(foodItemName);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DoesFoodItemWithSameNameExists_Should_Return_True_When_FoodItem_Exist()
        {
            // Arrange
            var foodItemName = "Test";

            var foodItem = new FoodItem { Name = "Test", Price = 5.00m, StatusId = (int)Status.Available };
            _context.FoodItem.Add(foodItem);
            _context.SaveChanges();

            // Act
            var result = await _foodItemService.DoesFoodItemWithSameNameExists(foodItemName);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
            await _context.DisposeAsync();
        }
    }

}