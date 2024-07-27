using DA_AppBanDoCu.ViewModels.Requests.Base;

namespace DA_AppBanDoCu.ViewModels.Requests
{
    public class OrderGetListRequest : BaseRequest
    {
    }

    public class OrderParam
    {
        public int MerchanID { get; set; }
    }

    public class OrderStatus
    {
        public int Status { get; set; }
    }

    public class OrderStatusCount
    {
        public string StatusName { get; set; }

        public int TotalCount { get; set; }
        public int Status { get; set; }
    }
}
