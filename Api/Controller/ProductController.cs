using Api.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller
{
    public class ProductController : StoreController
    {

        public ProductController(AppDbContext dbContext)
        : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());
        }
    }
}