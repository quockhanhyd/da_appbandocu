using System;

namespace DA_AppBanDoCu.ViewModels.Responses.Base
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Mã code
        /// </summary>
        public ResponseCode? ResponseCode { get; set; } = Base.ResponseCode.Success;
        /// <summary>
        /// Data
        /// </summary>
        public object? Data { get; set; } = null;
        /// <summary>
        /// Nội dung gửi cho dev nếu có lỗi
        /// </summary>
        public string? DevMsg { get; set; }
        /// <summary>
        /// Nội dung trả về cho người dùng nếu có lỗi
        /// </summary>
        public string? UserMsg { get; set; }
    }

    public enum ResponseCode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 0,
        /// <summary>
        /// Không có nội dung
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// KHông có quyền vào app
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// Chưa được cấp quyền
        /// </summary>
        ForbidResult = 403,
        /// <summary>
        /// Dữ liệu thiếu
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Không tìm thấy trang
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// Lỗi hệ thống
        /// </summary>
        ServerError = 500,
        /// <summary>
        /// Lỗi exception
        /// </summary>
        Exception = 999,
    }

    public enum ValidateCode
    {
        /// <summary>
        /// Trùng mã
        /// </summary>
        Unique = 0,

        /// <summary>
        /// Chưa có khóa chính
        /// </summary>
        NoPrimaryKey = 1,

        /// <summary>
        /// Chưa có giá trị
        /// </summary>
        NoValue = 2,
    }

    public class ValidateError
    {
        /// <summary>
        /// Trạng thái validate
        /// </summary>
        public bool ValidateResult { get; set; } = true;
        /// <summary>
        /// Mã code validate
        /// </summary>
        public ValidateCode ValidateCode { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public object? Data { get; set; } = null;
        /// <summary>
        /// Nội dung cho dev
        /// </summary>
        public string? DevMsg { get; set; }

    }
    public enum ModelState
    {
        /// <summary>
        /// Thêm
        /// </summary>
        Insert = 1,
        /// <summary>
        /// Sửa
        /// </summary>
        Update = 2,
        /// <summary>
        /// Xóa
        /// </summary>
        Delete = 3,
        /// <summary>
        /// Nhân bản
        /// </summary>
        Duplicate = 4,
    }
}
