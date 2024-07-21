using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class OrderDetailEntity : BaseModel
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public required string OrderCode { get; set; }
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
}
