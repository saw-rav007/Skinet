using API.Data;
using API.Enitities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _context.Products.ToList();

            return products;
        }


        [HttpGet("{id}")]
        public string GetProductsById(int id)
        {
            return "This will return the proucts by id!";
        }
    }
}