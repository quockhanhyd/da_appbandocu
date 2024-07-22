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

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Result.GetResultOk(path);
        }
    }
}
