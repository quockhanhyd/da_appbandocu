
namespace DA_AppBanDoCu.Entity
{
    public class RoleEntity : BaseModel // Quyền
    {
        public int RoleID { get; set; }
        public required string RoleName { get; set; } // Tên quyền
    }
}
