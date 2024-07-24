using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Mvc;

namespace DA_AppBanDoCu.Controllers
{
    /// <summary>
    /// Quản lý người dùng
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[AuthenPermission]
    public class UploadController : Authentication
    {
        [HttpPost]
        [Route("upload")]
        public async Task<Result> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Result.GetResultError("No file uploaded.");
            var newGuid = Guid.NewGuid().ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{newGuid}_{file.FileName}");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //Thay bằng địa chỉ ip máy mình
            var url = "https://192.168.0.107:7156";
            // Tạo URL công khai
            var fileUrl = $"{url}/images/{newGuid}_{file.FileName}";

            return Result.GetResultOk(fileUrl);
        }
    }
}
