using System.Net;
using Api.Data;
using Api.Model;
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
            ResponseServer response = new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = await dbContext.Products.ToListAsync()
            };

            return Ok(response);
        }
    }
}