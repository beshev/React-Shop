namespace Infrastructure.Common
{
    using Infrastructure.Constants;
    using System;
    using System.Collections.Generic;

    public class InternalResult<T>
    {
        private readonly HashSet<string> errors = [];

        public InternalResult(T data, int code = InternalStatusCodesConstant.Success)
        {
            Data = data;
            IsSuccess = true;
            Code = code;
        }

        public InternalResult(string message, int code, string error)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException($"{nameof(InternalResult<T>)}.{nameof(Message)}");
            }

            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException($"{nameof(InternalResult<T>)}.{nameof(Errors)}");
            }

            Message = message;
            Code = code;
            IsSuccess = false;
            errors.Add(error);
        }

        public T Data { get; }

        public bool IsSuccess { get; }

        public int Code { get; }

        public string Message { get; set; }

        public IEnumerable<string> Errors => errors;
    }
}
