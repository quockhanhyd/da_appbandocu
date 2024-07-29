using DA_AppBanDoCu.Entity;
namespace DA_AppBanDoCu.Entity
{
    public class OrderEntity : BaseModel
    {
        public int OrderID { get; set; }
        public required string OrderCode { get; set; }
        public int UserID { get; set; } // ng mua
        public int MerchanID { get; set; } // ng bán
        public int TotalPrice { get; set; }
        public string? Address { get; set; } // Địa chỉ
        public int ProvinceID { get; set; } // Tỉnh/TP
        public int DistrictID { get; set; } // Quận/Huyện
        public int WardID { get; set; } // Xã/Phường
        public int IsDefault { get; set; } // Địa chỉ mặc định
        public string? Note { get; set; }
        public int Status { get; set; } // todo
    }
}
