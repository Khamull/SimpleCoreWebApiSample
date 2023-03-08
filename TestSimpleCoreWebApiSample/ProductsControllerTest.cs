using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCoreWebApiSample.Controllers;
using SimpleCoreWebApiSample.Db;
using SimpleCoreWebApiSample.Entities;

namespace TestSimpleCoreWebApiSample
{
    [TestFixture]
    public class ProductsControllerTest
    {
        private AppDbContext _context;
        private ProductsController _controller;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;
            _context = new AppDbContext(options);
            SeedData();
            _controller = new ProductsController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void GetProducts_ReturnsAllProducts()
        {
            // Arrange

            // Act            
            
            var result = _controller.Get();
            var products = result.ToList<Product>();

            // Assert
            Assert.AreEqual(3, products.Count);
        }

        private void SeedData()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" }
            };
            _context.Categories.AddRange(categories);

            var suppliers = new List<Supplier>
            {
                new Supplier { Id = 1, Name = "Supplier 1" },
                new Supplier { Id = 2, Name = "Supplier 2" }
            };
            _context.Suppliers.AddRange(suppliers);

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.00m, CategoryId = 1, SupplierId = 1 },
                new Product { Id = 2, Name = "Product 2", Price = 20.00m, CategoryId = 1, SupplierId = 2 },
                new Product { Id = 3, Name = "Product 3", Price = 30.00m, CategoryId = 2, SupplierId = 1 }
            };
            _context.Products.AddRange(products);

            _context.SaveChanges();
        }
    }
}