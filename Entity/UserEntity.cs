namespace DA_AppBanDoCu.Entity
{
    public class UserEntity : BaseModel // Người dùng
    {
        public int UserID { get; set; }
        public required string Username { get; set; } // Tên đăng nhập
        public required string Password { get; set; } // MK
        public required string Fullname { get; set; } // Tên
        public int RoleID { get; set; } // Quyền
    }
}
