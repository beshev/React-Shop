namespace React_Shop.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using React_Shop.Server.Commands;
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
        public async Task<IActionResult> Create(ProductCreateApiModel product, CancellationToken cancellationToken)
        {
            var command = Mapper.Map<CreateProductCommand>(product);

            var result = await Mediator.Send(command, cancellationToken);
            if (!result.IsSuccess)
            {
                return CreateErrorResult(result);
            }

            return Ok(result.Data);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(ProductCreateApiModel product, CancellationToken cancellationToken)
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
