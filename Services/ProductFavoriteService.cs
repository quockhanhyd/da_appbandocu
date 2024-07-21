using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IProductFavoriteService
    {
        public string GetList(ProductFavoriteGetListRequest input, out dynamic result);
        public string InsertOrUpdate(ProductFavoriteEntity input);
        public string Delete(int ProductFavoriteID);
    }
    public class ProductFavoriteService : IProductFavoriteService
    {
        private readonly PkContext _context;
        public ProductFavoriteService() 
        {
            _context = new PkContext();
        }

        public string Delete(int ProductFavoriteID)
        {
            ProductFavoriteEntity user = _context.ProductFavorites.FirstOrDefault(x => x.ProductFavoriteID == ProductFavoriteID);
            if (user == null) return "Không tồn tại bản ghi có ProductFavoriteID = " + ProductFavoriteID;

            _context.ProductFavorites.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(ProductFavoriteGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.ProductFavorites.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.ProductFavorites.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(ProductFavoriteEntity input)
        {
            if (input.ProductFavoriteID == 0) {
                _context.ProductFavorites.Add(input);
            }
            else
            {
                _context.ProductFavorites.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
