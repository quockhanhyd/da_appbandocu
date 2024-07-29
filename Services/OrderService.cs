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
        public string GetListByMerchanID(OrderParam input, out dynamic result);
        public string GetByStatus(OrderStatus input, out dynamic result);
        public string GetById(OrderDetailParam input, out dynamic result);
        public string UpdateStatus(UpdateStatusOrder input, out dynamic result);
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
            if (input.OrderID == 0)
            {
                _context.Orders.Add(input);
            }
            else
            {
                _context.Orders.Update(input);
            }
            _context.SaveChanges();
            return "";
        }

        public string GetListByMerchanID(OrderParam input, out dynamic result)
        {
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            //var data = _context.Orders.Where(x => x.MerchanID == input.MerchanID).ToList(); // Lấy tất cả dữ liệu trước
            var data = _context.Orders.ToList(); // Lấy tất cả dữ liệu trước
            // 1: Chờ xác nhận, 2: Chờ lấy hàng, 3: Đang giao hàng, 4 :Hoàn thành, 5: Hủy
            result = new List<OrderStatusCount>
            {
                new OrderStatusCount
                {
                    StatusName = "Tất cả",
                    TotalCount = data.Count(),
                    Status = 0
                },
                new OrderStatusCount
                {
                    StatusName = "Chờ xác nhận",
                    TotalCount = data.Count(x => x.Status == 1),
                    Status = 1
                },
                new OrderStatusCount
                {
                    StatusName = "Chờ lấy hàng",
                    TotalCount = data.Count(x => x.Status == 2),
                    Status = 2
                },
                new OrderStatusCount
                {
                    StatusName = "Đang giao hàng",
                    TotalCount = data.Count(x => x.Status == 3),
                    Status = 3
                },
                new OrderStatusCount
                {
                    StatusName = "Hoàn thành",
                    TotalCount = data.Count(x => x.Status == 4),
                    Status = 4
                },
                new OrderStatusCount
                {
                    StatusName = "Hủy",
                    TotalCount = data.Count(x => x.Status == 5),
                    Status = 5
                },
            };
            return "";
        }

        public string GetByStatus(OrderStatus input, out dynamic result)
        {
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Orders.Where(x => input.Status == 0 || x.Status == input.Status).ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data,
                Total = data.Count()
            };
            return "";
        }

        public string GetById(OrderDetailParam input, out dynamic result)
        {
            var data = _context.Orders.Where(x => x.OrderID == input.OrderId).FirstOrDefault(); // Lấy tất cả dữ liệu trước
            if (data == null)
            {
                result = $"Không có dữ liệu {input.OrderId}";
                return result;
            }
            var ordertails = _context.OrderDetails.Where(x => x.OrderID == input.OrderId).ToList();
            result = new
            {
                Order = data,
                OrderDetail = ordertails,
            };
            return "";
        }

        public string UpdateStatus(UpdateStatusOrder input, out dynamic result)
        {
            var order = _context.Orders.Where(x => x.OrderID == input.OrderId).FirstOrDefault(); // Lấy tất cả dữ liệu trước
            if (order == null)
            {
                result = $"Không có dữ liệu {input.OrderId}";
                return result;
            }
            if (input.Accept)
            {
                order.Status += 1;
            }
            else
            {
                order.Status = 5;
            }
            _context.Orders.Update(order); // Lấy tất cả dữ liệu trước
            var res = _context.SaveChanges();
            result = new
            {
                UpdateSuccess = res == 1 ? true : false,
            };
            return "";
        }
    }
}
