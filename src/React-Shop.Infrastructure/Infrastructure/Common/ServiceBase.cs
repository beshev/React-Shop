namespace Infrastructure.Common
{
    using Infrastructure.Constants;
    using System.Collections.Generic;

    public class ServiceBase
    {
        protected virtual InternalResult<T> Success<T>(T data, int code = InternalStatusCodeConstant.Success)
        {
            return new InternalResult<T>(data, code);
        }

        protected virtual InternalResult<bool> BadRequest(string message, string error)
        {
            return new InternalResult<bool>(message, InternalStatusCodeConstant.BadRequest, ErrorTypeConstants.BadRequest, error);
        }

        protected virtual InternalResult<T> ValidationError<T>(string message, string error)
        {
            return new InternalResult<T>(message, InternalStatusCodeConstant.BadRequest, ErrorTypeConstants.Validation, error);
        }

        protected virtual InternalResult<T> ValidationError<T>(string message, IEnumerable<string> errors)
        {
            return new InternalResult<T>(message, InternalStatusCodeConstant.BadRequest, ErrorTypeConstants.Validation, errors);
        }
    }
}
