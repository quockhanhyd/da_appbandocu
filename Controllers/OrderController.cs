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
    public class OrderController : Authentication
    {
        private readonly IOrderService _dataService;
        public OrderController(IOrderService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("GetList")]
        public Result GetList(OrderGetListRequest input)
        {
            string msg = _dataService.GetList(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("InsertOrUpdate")]
        public Result InsertOrUpdate(OrderEntity input)
        {
            string msg = _dataService.InsertOrUpdate(input);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpDelete("Delete")]
        public Result Delete(int OrderID)
        {
            string msg = _dataService.Delete(OrderID);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpPost("GetTotalOrderByMerchanID")]
        public Result GetNumberTotalOrder(OrderParam input)
        {
            string msg = _dataService.GetListByMerchanID(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("GetByStatus")]
        public Result GetByStatus(OrderStatus input)
        {
            string msg = _dataService.GetByStatus(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("GetById")]
        public Result GetOrderDetail(OrderDetailParam input)
        {
            string msg = _dataService.GetById(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("UpdateStatus")]
        public Result UpdateStatus(UpdateStatusOrder input)
        {
            string msg = _dataService.UpdateStatus(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }
    }
}
