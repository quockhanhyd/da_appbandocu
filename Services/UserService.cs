using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IUserService
    {
        public string GetList(UserGetListRequest input, out dynamic result);
        public string InsertOrUpdate(UserEntity input);
        public string Delete(int UserID);
    }
    public class UserService : IUserService
    {
        private readonly PkContext _context;
        public UserService() 
        {
            _context = new PkContext();
        }

        public string Delete(int UserID)
        {
            UserEntity user = _context.Users.FirstOrDefault(x => x.UserID == UserID);
            if (user == null) return "Không tồn tại bản ghi có UserID = " + UserID;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(UserGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Users.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Users.ToList() // Lấy tất cả dữ liệu trước
                .Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch));

            // Áp dụng các thao tác lọc trên dữ liệu đã tải
            var filteredUsers = data
                .Skip((input.CurrentPage - 1) * input.PageSize)
                .Take(input.PageSize)
                .ToList();

            var roleIds = filteredUsers.Select(u => u.RoleID).Distinct();

            var roles = _context.Roles.Where(r => roleIds.Contains(r.RoleID)).ToDictionary(r => r.RoleID);

            result = new
            {
                Data = filteredUsers.Select(u =>
                {
                    var userResponse = u.MapObject<UserEntity, UserResponse>();
                    userResponse.RoleName = roles.TryGetValue(u.RoleID, out var role) ? role.RoleName : null;
                    return userResponse;
                }).ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(UserEntity input)
        {
            if (input.UserID == 0) {
                _context.Users.Add(input);
            }
            else
            {
                _context.Users.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
