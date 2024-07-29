using DA_AppBanDoCu.ViewModels.Requests.Base;

namespace DA_AppBanDoCu.ViewModels.Requests
{
    public class CartGetListRequest : BaseRequest
    {
    }
    public class AddToCartRequest
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}
