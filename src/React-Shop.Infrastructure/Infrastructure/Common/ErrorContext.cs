namespace Infrastructure.Common
{
    using System;

    public class ErrorContext
    {
        public ErrorContext(string titile)
        {
            if (string.IsNullOrWhiteSpace(titile))
            {
                throw new ArgumentException($"{nameof(ErrorContext)}.{nameof(Title)}");
            }

            Title = titile;
        }

        public string Title { get; set; }
    }
}
