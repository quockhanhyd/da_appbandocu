using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface ICategoryService
    {
        public string GetList(CategoryGetListRequest input, out dynamic result);
        public string InsertOrUpdate(CategoryEntity input);
        public string Delete(int CategoryID);
    }
    public class CategoryService : ICategoryService
    {
        private readonly PkContext _context;
        public CategoryService() 
        {
            _context = new PkContext();
        }

        public string Delete(int CategoryID)
        {
            CategoryEntity user = _context.Categorys.FirstOrDefault(x => x.CategoryID == CategoryID);
            if (user == null) return "Không tồn tại bản ghi có CategoryID = " + CategoryID;

            _context.Categorys.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(CategoryGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Categorys.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Categorys.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(CategoryEntity input)
        {
            if (input.CategoryID == 0) {
                _context.Categorys.Add(input);
            }
            else
            {
                _context.Categorys.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
