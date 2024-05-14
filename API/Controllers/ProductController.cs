using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DTOs;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Route(nameof(GetAllProducts))]

        public async Task<IActionResult> GetAllProducts()
        {
            var res = await _productService.GetAllAsync();
            return Ok(res);

        }


        [HttpPost]
        [Route(nameof(AddNewProduct))]

        public async Task<IActionResult> AddNewProduct([FromBody]AddProductDTO model)
        {
            var res = await _productService.AddNewProductAsync(model);
            if (res)
                return Ok();
            return BadRequest();
        }


        [HttpPut]
        [Route(nameof(UpdateProduct))]

        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO model)
        {
            var productToBeUpdate = await _productService.GetProductByIdAsync(model.Id);

            if (productToBeUpdate == null)
                return NotFound();

            var res = await _productService.UpdateProductAsync(model);
            if (res)
                return Ok();
            return BadRequest();
        }


        [HttpDelete]
        [Route(nameof(DeleteProduct))]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            var res = await _productService.DeleteProductAsync(id);
            if (res)
                return Ok();
            return BadRequest();
        }


    }
}
