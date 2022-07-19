using Microsoft.EntityFrameworkCore;
using ShopBridge.Controllers;
using ShopBridge.Data;
using ShopBridge.Models;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void InventoryList_NotNull()
        {
            // Arrange
            var applicationDbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            ProductController controller = new ProductController(applicationDbContext);

            // Act

            var result = applicationDbContext.Product.ToListAsync();
            // Assert
            Assert.IsNotNull(result);

        }

       
        [Test]
        public async Task CreateAndDeleteProduct()
        {
            // Arrange
            var applicationDbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            ProductController controller = new ProductController(applicationDbContext);

            var product = new Product() { ProductId = 9999, ProductName = "TestProduct", Price = 1000, Quantity = 50, Description = "This is TestProduct description" };
            // Act & Assert
            try
            {
                var result= await controller.Create(product);
                var result1 = controller.Delete(9999);
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.IsTrue(false);
            }
            
        }
    }
}