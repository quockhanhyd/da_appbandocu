﻿using DA_AppBanDoCu.Atrributes;
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
    public class CartController : Authentication
    {
        private readonly ICartService _dataService;
        public CartController(ICartService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("GetList")]
        public Result GetList(CartGetListRequest input)
        {
            string msg = _dataService.GetList(input, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }

        [HttpPost("InsertOrUpdate")]
        public Result InsertOrUpdate(CartEntity input)
        {
            string msg = _dataService.InsertOrUpdate(input);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpDelete("Delete")]
        public Result Delete(int CartID)
        {
            string msg = _dataService.Delete(CartID);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpPost("AddToCart")]
        public Result AddToCart(AddToCartRequest input)
        {
            string msg = _dataService.AddToCart(input);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk();
        }

        [HttpPost("Order")]
        public Result Order([FromBody] int UserID)
        {
            string msg = _dataService.Order(UserID, out object result);
            if (!msg.IsEmpty()) return Result.GetResultError(msg);

            return Result.GetResultOk(result);
        }
    }
}
