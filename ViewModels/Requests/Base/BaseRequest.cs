namespace DA_AppBanDoCu.ViewModels.Requests.Base
{
    public class BaseRequest
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string TextSearch { get; set; } = string.Empty;
    }
}
