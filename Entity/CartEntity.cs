using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class CartEntity : BaseModel
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
