namespace React_Shop.Server.Controllers
{
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class AbstractController : ControllerBase
    {
        protected readonly IMediator _mediator;
        
        // TODO: double-check this
        public IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>();

        protected IActionResult CreateErrorResult<T>(InternalResult<T> result)
        {
            // TODO: Create an internal error class
            var error = new { result.Message, result.Code, result.Errors };

            return result.Code switch
            {
                InternalStatusCodesConstant.NotFound => NotFound(),
                InternalStatusCodesConstant.NoContent => NoContent(),
                InternalStatusCodesConstant.BadRequest => BadRequest(error),
                _ => StatusCode(InternalStatusCodesConstant.InternalServerError, error),
            };
        }
    }
}
