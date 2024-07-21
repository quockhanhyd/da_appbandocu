namespace DA_AppBanDoCu.ViewModels.Responses
{
    public class UserResponse
    {
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Fullname { get; set; }
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public int PositionID { get; set; }
        public string? PositionName { get; set; }
        public int SpecialistID { get; set; }
        public string? SpecialistName { get; set; }
        public string? ClinicName { get; set; }
        public int ClinicID { get; set; }
    }
}
