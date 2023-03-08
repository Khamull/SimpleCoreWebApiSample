using Microsoft.AspNetCore.Mvc;
using SimpleCoreWebApiSample.Db;
using SimpleCoreWebApiSample.Entities;

namespace SimpleCoreWebApiSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.SupplierId = product.SupplierId;
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                _context.SaveChanges();
            }
        }
    }
}
