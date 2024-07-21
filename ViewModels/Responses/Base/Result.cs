namespace DA_AppBanDoCu.ViewModels.Responses.Base
{
    public class Result
    {
        public int Status { get; set; } = 200;
        public bool IsOk { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
        public object? Data { get; set; }

        public static Result GetResultOk(object? data = null)
        {
            return new Result() { Data = data };
        }

        public static Result GetResultError(string errorMessage, object? data = null)
        {
            return new Result() 
            {
                Status = 400,
                IsOk = false,
                ErrorMessage = errorMessage,
                Data = data 
            };
        }
    }
}
