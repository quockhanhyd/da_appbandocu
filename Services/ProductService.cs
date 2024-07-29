using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DA_AppBanDoCu.Services
{
    public interface IProductService
    {
        public string GetList(ProductGetListRequest input, out dynamic result);
        public string GetListHome(ProductGetListRequest input, out dynamic result);
        public string GetDetail(int productID, out dynamic result);
        public string InsertOrUpdate(ProductEntity input);
        public string Delete(int ProductID);
    }
    public class ProductService : IProductService
    {
        private readonly PkContext _context;
        public ProductService()
        {
            _context = new PkContext();
        }

        public string Delete(int ProductID)
        {
            ProductEntity user = _context.Products.FirstOrDefault(x => x.ProductID == ProductID);
            if (user == null) return "Không tồn tại bản ghi có ProductID = " + ProductID;

            _context.Products.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetDetail(int productID, out dynamic result)
        {
            result = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            return "";
        }

        public string GetList(ProductGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Products.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Products.ToList() // Lấy tất cả dữ liệu trước
                .Where(u => u.ProductName.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize)
                .Take(input.PageSize)
                .Select(u => new
                {
                    u.ProductID,
                    u.ProductName,
                    u.TotalAmount,
                    u.TotalSold,
                    u.Vote,
                    u.Price,
                    u.PriceSale,
                    u.PercentSale,
                    u.Description,
                    u.ImageUrl,
                    u.CategoryID,
                    CategoryName = _context.Categorys.Where(x => x.CategoryID == u.CategoryID)?.FirstOrDefault()?.CategoryName,
                });

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string GetListHome(ProductGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            var data = from product in _context.Products
                       select new
                       {
                           ProductId = product.ProductID,
                           Image = product.ImageUrl,
                           BrandName = "SecondHand",
                           ProductName = product.ProductName,
                           Price = product.Price,
                           PriceAfetDiscount = product.PriceSale,
                           Dicountpercent = product.PercentSale,
                       };

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(ProductEntity input)
        {
            if (input.ProductID == 0)
            {
                _context.Products.Add(input);
            }
            else
            {
                _context.Products.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
