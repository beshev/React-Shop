namespace React_Shop.Server.Controllers
{
    using Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var prducts = await _productService.GetAllAsync(cancellationToken);
            return Ok(prducts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateAsync(product, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var result = await _productService.DeleteAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
