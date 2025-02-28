namespace OrderFlow.Application.DTOs.Response.Primitive
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; protected set; }
        public List<string> Errors { get; protected set; } = [];

        protected BaseResponse()
        {
            IsSuccess = true;
        }

        protected static T Failure<T>(string error) where T : BaseResponse, new()
        {
            var response = new T
            {
                IsSuccess = false,
                Errors = [error]
            };
            return response;
        }

        protected static T Failure<T>(IEnumerable<string> errors) where T : BaseResponse, new()
        {
            var response = new T
            {
                IsSuccess = false,
                Errors = errors.ToList()
            };
            return response;
        }
    }
}
