using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class UserAddressEntity : BaseModel
    {
        public int UserAddressID { get; set; }
        public int UserID { get; set; }
        public required string Address { get; set; } // Địa chỉ
        public int ProvinceID { get; set; } // Tỉnh/TP
        public int DistrictID { get; set; } // Quận/Huyện
        public int WardID { get; set; } // Xã/Phường
        public int IsDefault { get; set; } // Địa chỉ mặc định
    }
}
