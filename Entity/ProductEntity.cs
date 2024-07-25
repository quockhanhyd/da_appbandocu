using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class ProductEntity : BaseModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } // tên sản phẩm
        public int TotalAmount { get; set; } // số lượng trong kho
        public int TotalSold { get; set; } // số lượng đã bán
        public float Vote { get; set; } // đánh giá /5 sao
        public double Price { get; set; } // giá bán
        public double PriceSale { get; set; } // giá giảm
        public int PercentSale { get; set; } // phần trăm giảm giá
        public string? Description { get; set; } // mô tả
        public string ImageUrl { get; set; } // ảnh chính 'url1,url2'
        public int CategoryID { get; set; }// Danh mục
    }
}
