namespace DA_AppBanDoCu.Entity
{
    public class CategoryEntity : BaseModel // Danh mục sản phẩm
    {
        public int CategoryID { get; set; }
        public required string CategoryName { get; set; } // Tên danh mục sản phẩm
        public string? Description { get; set; } // Mô tả
        public int Status { get; set; } // Trạng thái
        public int ParentID { get; set; } // ID cha
    }
}
