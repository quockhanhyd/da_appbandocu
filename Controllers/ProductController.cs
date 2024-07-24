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
    public class ProductController : Authentication
    {
        private readonly IProductService _dataService;
        public ProductController(IProductService dataService)
        {
            _dataService = dataService;
        }


        [HttpPost("GetListHome")]
        public Result GetListHome(ProductGetListRequest input)
        {
            string msg = _dataService.GetListHome(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("GetDetail")]
        public Result GetDetail([FromBody] int productID)
        {
            string msg = _dataService.GetDetail(productID, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("GetList")]
        public Result GetList(ProductGetListRequest input)
        {
            string msg = _dataService.GetList(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("InsertOrUpdate")]
        public Result InsertOrUpdate(ProductEntity input)
        {
            string msg = _dataService.InsertOrUpdate(input);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpDelete("Delete")]
        public Result Delete(int ProductID)
        {
            string msg = _dataService.Delete(ProductID);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }
    }
}
