using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Services;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace DA_AppBanDoCu.Controllers
{
    public class Authentication : ControllerBase
    {
        public Result ResultCheckToken = null;
        public Authentication()
        {
        }

    }
}
