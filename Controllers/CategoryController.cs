using DA_AppBanDoCu.Atrributes;
using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Services;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Mvc;

namespace DA_AppBanDoCu.Controllers
{
    /// <summary>
    /// Danh sách quyền
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[AuthenPermission]
    public class CategoryController : Authentication
    {
        private readonly ICategoryService _dataService;
        public CategoryController(ICategoryService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("GetList")]
        public Result GetList(CategoryGetListRequest input)
        {
            string msg = _dataService.GetList(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("InsertOrUpdate")]
        public Result InsertOrUpdate(CategoryEntity input)
        {
            string msg = _dataService.InsertOrUpdate(input);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpDelete("Delete")]
        public Result Delete(int CategoryID)
        {
            string msg = _dataService.Delete(CategoryID);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }
    }
}
