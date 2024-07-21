using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IOrderDetailService
    {
        public string GetList(OrderDetailGetListRequest input, out dynamic result);
        public string InsertOrUpdate(OrderDetailEntity input);
        public string Delete(int OrderDetailID);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly PkContext _context;
        public OrderDetailService() 
        {
            _context = new PkContext();
        }

        public string Delete(int OrderDetailID)
        {
            OrderDetailEntity user = _context.OrderDetails.FirstOrDefault(x => x.ID == OrderDetailID);
            if (user == null) return "Không tồn tại bản ghi có OrderDetailID = " + OrderDetailID;

            _context.OrderDetails.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(OrderDetailGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.OrderDetails.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.OrderDetails.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(OrderDetailEntity input)
        {
            if (input.ID == 0) {
                _context.OrderDetails.Add(input);
            }
            else
            {
                _context.OrderDetails.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
