namespace Infrastructure.Constants
{
    using System.Net;

    public static class InternalStatusCodeConstant
    {
        public const int Success = (int)HttpStatusCode.OK;

        public const int NotFound = (int)HttpStatusCode.NotFound;

        public const int NoContent = (int)HttpStatusCode.NoContent;

        public const int Created = (int)HttpStatusCode.Created;

        public const int BadRequest = (int)HttpStatusCode.BadRequest;

        public const int InternalServerError = (int)HttpStatusCode.InternalServerError;
    }
}
