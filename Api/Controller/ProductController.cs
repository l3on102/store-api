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

        [HttpGet("{id}", Name = nameof(GetProductById))]
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
        [FromBody] ProductCreateDto productCreateDto
        )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productCreateDto.Image == null
                || productCreateDto.Image.Length == 0)
                    {
                        return BadRequest(new ResponseServer
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            IsSuccess = false,
                            ErrorMessages = new() { "Image не может быть пустым" }
                        });
                    }
                    else
                    {
                        Product item = new()
                        {
                            Name = productCreateDto.Name,
                            Description = productCreateDto.Description,
                            SpecialTag = productCreateDto.SpecialTag,
                            Category = productCreateDto.Category,
                            Price = productCreateDto.Price,
                            Image = $"https://imgplaceholdr.com/250x250/cccccc/969696/png?text_size=40"
                        };
                        await dbContext.Products.AddAsync(item);
                        await dbContext.SaveChangesAsync();

                        ResponseServer response = new()
                        {
                            StatusCode = HttpStatusCode.Created,
                            Result = item
                        };

                        return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
                    }
                }
                else
                {
                    return BadRequest(new ResponseServer
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = new() { "Модель данных не подходит" }
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = new() { "Что то пошло не так", ex.Message }
                });
            }

        }
    }
}


