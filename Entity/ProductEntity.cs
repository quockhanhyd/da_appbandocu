using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class ProductEntity : BaseModel
    {
        public int ProductID { get; set; }
        public required string ProductName { get; set; } // tên sản phẩm
        public required string Slug { get; set; } // đường dẫn
        public int TotalAmount { get; set; } // số lượng trong kho
        public int TotalSold { get; set; } // số lượng đã bán
        public float Vote { get; set; } // đánh giá /5 sao
        public int Price { get; set; } // giá bán
        public int PriceSale { get; set; } // giá giảm
        public int PercentSale { get; set; } // phần trăm giảm giá
        public string? Description { get; set; } // mô tả
        public string? DescriptionHtml { get; set; } // mô tả dài
        public required string ImageUrl { get; set; } // ảnh
    }
}
