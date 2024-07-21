using DA_AppBanDoCu.Entity;

namespace DA_AppBanDoCu.Entity
{
    public class ChatEntity : BaseModel
    {
        public int ChatID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public required string Message { get; set; }
    }
}
