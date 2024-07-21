using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Services;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DA_AppBanDoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Authentication
    {
        protected readonly IConfiguration _configuration;
        private readonly PkContext _context;
        private readonly IUserService _dataService;
        public AuthenticationController(IUserService dataService, IConfiguration configuration)
        {
            _dataService = dataService;
            _context = new PkContext();
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public Result GetList([FromBody] SignInRequest input)
        {
            UserEntity user = _context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(input.Username.Trim().ToLower()));
            if (user == null || !user.Password.Equals(input.Password)) return Result.GetResultError("Tài khoản hoặc mật khẩu không chính xác!");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, input.Username),
                new Claim(JwtRegisteredClaimNames.Sid, user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Result.GetResultOk(new
            {
                UserInfo = user,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }
    }
}
