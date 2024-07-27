using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            // Lấy tên máy tính
            string hostName = Dns.GetHostName();

            // Lấy thông tin về máy chủ dựa trên tên máy tính
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            // Tìm địa chỉ IP IPv4
            string ipAddress = hostEntry.AddressList
                .LastOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                .ToString() ?? "localhost";

            //Thay bằng địa chỉ ip máy mình
            var url = $"https://{ipAddress}:7156";
            // Tạo URL công khai
            var fileUrl = $"{url}/images/{newGuid}_{file.FileName}";

            return Result.GetResultOk(fileUrl);
        }
    }
}
