using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IOrderService
    {
        public string GetList(OrderGetListRequest input, out dynamic result);
        public string InsertOrUpdate(OrderEntity input);
        public string Delete(int OrderID);
    }
    public class OrderService : IOrderService
    {
        private readonly PkContext _context;
        public OrderService() 
        {
            _context = new PkContext();
        }

        public string Delete(int OrderID)
        {
            OrderEntity user = _context.Orders.FirstOrDefault(x => x.OrderID == OrderID);
            if (user == null) return "Không tồn tại bản ghi có OrderID = " + OrderID;

            _context.Orders.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(OrderGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Orders.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Orders.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(OrderEntity input)
        {
            if (input.OrderID == 0) {
                _context.Orders.Add(input);
            }
            else
            {
                _context.Orders.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
