namespace React_Shop.Server.Controllers
{
    using AutoMapper;
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class AbstractController : ControllerBase
    {
        protected IMediator _mediator;
        protected IMapper _mapper;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        public IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

        protected IActionResult CreateErrorResult<T>(InternalResult<T> result)
        {
            // TODO: Create an internal error class
            var error = new { result.Message, result.Code, result.Errors };

            return result.Code switch
            {
                InternalStatusCodeConstant.NotFound => NotFound(),
                InternalStatusCodeConstant.NoContent => NoContent(),
                InternalStatusCodeConstant.BadRequest => BadRequest(error),
                _ => StatusCode(InternalStatusCodeConstant.InternalServerError, error),
            };
        }
    }
}
