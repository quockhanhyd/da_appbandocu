using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class ProductFavoriteEntity : BaseModel
    {
        public int ProductFavoriteID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}
