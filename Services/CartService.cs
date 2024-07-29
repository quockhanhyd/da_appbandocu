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
        public string AddToCart(AddToCartRequest input);
        public string Order(int UserID, out dynamic result);
    }
    public class CartService : ICartService
    {
        private readonly PkContext _context;
        public CartService() 
        {
            _context = new PkContext();
        }

        public string AddToCart(AddToCartRequest input)
        {
            try
            {
                CartEntity cart = _context.Carts.FirstOrDefault(c => c.ProductID == input.ProductID && c.UserID == input.UserID);
                if (cart == null)
                {
                    _context.Carts.Add(new CartEntity()
                    {
                        ProductID = input.ProductID,
                        Quantity = 1,
                        UserID = input.UserID,
                    });
                }
                else
                {
                    cart.Quantity++;
                    _context.Carts.Update(cart);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
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

            var data = from cart in _context.Carts
                       join product in _context.Products on cart.ProductID equals product.ProductID
                       select new
                       {
                           CartId = cart.CartID,
                           ProductId = cart.ProductID,
                           cart.Quantity,
                           product.ProductName,
                           Price = product.PriceSale,
                           Total = product.PriceSale * cart.Quantity,
                           product.ImageUrl,
                       }; // Lấy tất cả dữ liệu trước

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

        public string Order(int UserID, out dynamic result)
        {
            result = "";
            try
            {
                var data = (from cart in _context.Carts
                            join product in _context.Products on cart.ProductID equals product.ProductID
                            where cart.UserID == UserID
                            select new
                            {
                                cart.CartID,
                                cart.Quantity,
                                product.ProductName,
                                product.PriceSale,
                                product.ProductID,
                            }).ToList();
                if (!data.Any()) return "Không tồn tại sản phẩm trong giỏ hàng";

                int lastId = _context.Orders.OrderByDescending(o => o.OrderID).FirstOrDefault()?.OrderID ?? 0;
                string orderCode = "DH" + (lastId + 1).ToString("D5");

                _context.Orders.Add(new OrderEntity()
                {
                    OrderCode = orderCode,
                    UserID = UserID,
                    TotalPrice = data.Sum(d => d.Quantity * d.PriceSale),
                    Address = ""
                });

                _context.OrderDetails.AddRange(data.Select(d => new OrderDetailEntity()
                {
                    OrderCode = orderCode,
                    OrderID = lastId + 1,
                    Price = d.PriceSale,
                    ProductName = d.ProductName,
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                }));

                _context.SaveChanges();
                result = orderCode;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
}
