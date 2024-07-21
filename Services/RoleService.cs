using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IRoleService
    {
        public string GetList(RoleGetListRequest input, out dynamic result);
        public string InsertOrUpdate(RoleEntity input);
        public string Delete(int RoleID);
        public string GetAllForCombobox(out dynamic result);
    }
    public class RoleService : IRoleService
    {
        private readonly PkContext _context;
        public RoleService() 
        {
            _context = new PkContext();
        }

        public string Delete(int RoleID)
        {
            RoleEntity user = _context.Roles.FirstOrDefault(x => x.RoleID == RoleID);
            if (user == null) return "Không tồn tại bản ghi có RoleID = " + RoleID;

            if (_context.Users.Where(x => x.RoleID == RoleID).Any())
                return "Không thể xóa bản ghi, do có dữ liệu";

            _context.Roles.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetAllForCombobox(out dynamic result)
        {
            result = _context.Roles.Select(x => new
            {
                x.RoleID,
                x.RoleName
            }).ToList();
            return "";
        }

        public string GetList(RoleGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Roles.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();
            
            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Roles.ToList()
                .Where(u => u.RoleName.RemoveVietnameseDiacritics().Contains(input.TextSearch));

            // Áp dụng các thao tác lọc trên dữ liệu đã tải
            result = new
            {
                Data = data
                .Skip((input.CurrentPage - 1) * input.PageSize)
                .Take(input.PageSize).Select(u => new
                {
                    u.RoleID,
                    u.RoleName,
                    TotalUser = _context.Users.Where(x => x.RoleID ==  u.RoleID).Count(),
                })
                .ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(RoleEntity input)
        {
            if (input.RoleID == 0) {
                _context.Roles.Add(input);
            }
            else
            {
                _context.Roles.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
