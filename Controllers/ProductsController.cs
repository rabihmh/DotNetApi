using DotNetApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Set<Product>().ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Set<Product>().Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product product)
        {
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
            return Ok(product.Id);
        }

        [HttpPut]
        [Route("")]
        public ActionResult UpdateProduct(Product product)
        {
            var existingProduct = _context.Set<Product>().Find(product.Id);
            if (existingProduct == null) return BadRequest();
            existingProduct.Name=product.Name;
            existingProduct.sku=product.sku;
            _context.Set<Product>().Update(existingProduct);
            _context.SaveChanges();
            return Ok("Update");

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Set<Product>().Find(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

    }
}
