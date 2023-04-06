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
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private GeneralStoreDbContext _db;
        public CustomerController(GeneralStoreDbContext db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm]CustomerEdit newCustomer) {
            Customer customer = new Customer() {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() {
            var customers = await _db.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}