namespace React_Shop.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using React_Shop.Server.Models;
    using React_Shop.Server.Queries;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : AbstractController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();
            var result = await Mediator.Send(query, cancellationToken);
            if (!result.IsSuccess)
            {
                return CreateErrorResult(result);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductApiModel product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductApiModel product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
