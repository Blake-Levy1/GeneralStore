using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private GeneralStoreDbContext _db;
        public ProductController(GeneralStoreDbContext db) {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductEdit newProduct)
        // [FromForm] just means its going to be in the body of a request in postman
        {
            Product product = new Product() {
                Name = newProduct.Name,
                Price = newProduct.Price,
                QuantityInStock = newProduct.Quantity,
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }
    }

}