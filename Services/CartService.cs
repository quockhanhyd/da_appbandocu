using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface ICartService
    {
        public string GetList(CartGetListRequest input, out dynamic result);
        public string InsertOrUpdate(CartEntity input);
        public string Delete(int CartID);
    }
    public class CartService : ICartService
    {
        private readonly PkContext _context;
        public CartService() 
        {
            _context = new PkContext();
        }

        public string Delete(int CartID)
        {
            CartEntity user = _context.Carts.FirstOrDefault(x => x.CartID == CartID);
            if (user == null) return "Không tồn tại bản ghi có CartID = " + CartID;

            _context.Carts.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(CartGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Carts.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Carts.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(CartEntity input)
        {
            if (input.CartID == 0) {
                _context.Carts.Add(input);
            }
            else
            {
                _context.Carts.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
