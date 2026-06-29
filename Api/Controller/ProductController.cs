using System.Net;
using Api.Data;
using Api.Model;
using Api.ModelDto;
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

        // [HttpGet]
        // public async Task<IActionResult> GetProducts()
        // {
        //     ResponseServer response = new ResponseServer
        //     {
        //         StatusCode = HttpStatusCode.OK,
        //         Result = await dbContext.Products.ToListAsync()
        //     };

        //     return Ok(response);
        // }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(
            new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = await dbContext.Products.ToListAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (id <= 0)
            {
                return BadRequest(new ResponseServer
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    ErrorMessages = { "неверный id" }
                });
            }

            if (product == null)
            {
                return NotFound(new ResponseServer
                {
                    StatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false,
                    ErrorMessages = { "продукт по указанному id не найден" }
                });
            }
            else
            {
                return Ok(
            new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = product
            });
            }

        }

        [HttpPost]
        public async Task<ActionResult<ResponseServer>> CreateProduct(
[FromBody] ProductCreateDto createDto
        )
        {

        }
    }
}


