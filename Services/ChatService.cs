using DA_AppBanDoCu.Entity;
using DA_AppBanDoCu.Entity.MyDbContext;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Requests;
using DA_AppBanDoCu.ViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Services
{
    public interface IChatService
    {
        public string GetList(ChatGetListRequest input, out dynamic result);
        public string InsertOrUpdate(ChatEntity input);
        public string Delete(int ChatID);
    }
    public class ChatService : IChatService
    {
        private readonly PkContext _context;
        public ChatService() 
        {
            _context = new PkContext();
        }

        public string Delete(int ChatID)
        {
            ChatEntity user = _context.Chats.FirstOrDefault(x => x.ChatID == ChatID);
            if (user == null) return "Không tồn tại bản ghi có ChatID = " + ChatID;

            _context.Chats.Remove(user);
            _context.SaveChanges();
            return "";
        }

        public string GetList(ChatGetListRequest input, out dynamic result)
        {
            input.TextSearch ??= string.Empty;
            input.TextSearch = input.TextSearch.RemoveVietnameseDiacritics();

            //result = context.Chats.Where(u => u.Fullname.RemoveVietnameseDiacritics().Contains(input.TextSearch)).Skip((input.CurrentPage - 1) * input.PageSize).Take(input.PageSize).ToList();

            // Tạm thời
            // Lấy tất cả bản ghi từ cơ sở dữ liệu
            var data = _context.Chats.ToList(); // Lấy tất cả dữ liệu trước

            result = new
            {
                Data = data.ToList(),
                Total = data.Count()
            };
            return "";
        }

        public string InsertOrUpdate(ChatEntity input)
        {
            if (input.ChatID == 0) {
                _context.Chats.Add(input);
            }
            else
            {
                _context.Chats.Update(input);
            }
            _context.SaveChanges();
            return "";
        }
    }
}
