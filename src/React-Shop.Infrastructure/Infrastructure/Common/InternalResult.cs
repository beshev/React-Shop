namespace Infrastructure.Common
{
    using Infrastructure.Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InternalResult<T>
    {
        private readonly HashSet<string> errors = [];

        private InternalResult(string message, int code, string type)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException($"{nameof(InternalResult<T>)}.{nameof(Message)}");
            }

            Message = message;
            Code = code;
            Type = type;
            IsSuccess = false;
        }

        public InternalResult(T data, int code = InternalStatusCodeConstant.Success)
        {
            Data = data;
            Code = code;
            IsSuccess = true;
        }

        public InternalResult(string message, int code, string type, string error)
            : this(message, code, type)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException($"{nameof(InternalResult<T>)}.{nameof(Errors)}");
            }

            errors.Add(error);
        }

        public InternalResult(string message, int code, string type, IEnumerable<string> errors)
            : this(message, code, type)
        {
            if (!errors.Any())
            {
                throw new ArgumentNullException($"{nameof(InternalResult<T>)}.{nameof(Errors)}");
            }

            errors.Union(errors);
        }

        public T Data { get; }

        public bool IsSuccess { get; }

        public int Code { get; }

        public string Type { get; }

        public string Message { get; set; }

        public IEnumerable<string> Errors => errors;
    }
}
