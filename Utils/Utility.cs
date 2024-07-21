using AutoMapper;
using System.Text.Json;

namespace DA_AppBanDoCu.Utils
{
    public static class Utility
    {
        public static string GetConfig(List<string> key, string str = "")
        {
            var appSettingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var appSettings = JsonSerializer.Deserialize<JsonElement>(json);
            var result = appSettings.GetProperty(key[0]);
            for (int i = 1; i < key.Count; i++) result = result.GetProperty(key[i]);
            return result.GetString() ?? str;
        } 

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static string RemoveVietnameseDiacritics(this string str)
        {
            //string[] VietnameseSigns =
            //[
            //"aAeEoOuUiIdDyY",
            //"áàạảãâấầậẩẫăắằặẳẵ",
            //"ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            //"éèẹẻẽêếềệểễ",
            //"ÉÈẸẺẼÊẾỀỆỂỄ",
            //"óòọỏõôốồộổỗơớờợởỡ",
            //"ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            //"úùụủũưứừựửữ",
            //"ÚÙỤỦŨƯỨỪỰỬỮ",
            //"íìịỉĩ",
            //"ÍÌỊỈĨ",
            //"đ",
            //"Đ",
            //"ýỳỵỷỹ",
            //"ÝỲỴỶỸ"
            //];

            //for (int i = 1; i < VietnameseSigns.Length; i++)
            //{
            //    for (int j = 0; j < VietnameseSigns[i].Length; j++)
            //        str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            //}
            //return str;
            return str;
        }
        public static T2 MapObject<T1, T2>(this T1 obj1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = new Mapper(config);
            return mapper.Map<T2>(obj1);
        }

        public static void CopyPropertiesToDynamic<T>(T source, dynamic destination)
        {
            var dictionary = (IDictionary<string, object>)destination;
            foreach (var prop in typeof(T).GetProperties())
            {
                dictionary[prop.Name] = prop.GetValue(source);
            }
        }

        public static string GetSexName(int Sex) => Sex switch
        {
            1 => "Nam",
            2 => "Nữ",
            _ => "Khác"
        };

        public static string GetExamStatusName(int Status) => Status switch
        {
            1 => "Chờ tới khám",
            2 => "Đã khám",
            3 => "Quá hạn",
            4 => "Đã hủy",
            _ => "Mới tạo"
        };

        // 1. Chờ khám; 2. Đang khám; 3. Chờ kết quả; 4. Đã có kết quả; 5. Hoàn thành; 6. Đã hủy
        public static string GetExamResultStatusName(int Status) => Status switch
        {
            1 => "Chờ khám",
            2 => "Đang khám",
            3 => "Chờ kết quả",
            4 => "Đã có kết quả",
            5 => "Hoàn thành",
            6 => "Đã hủy",
            _ => "Không xác định"
        };
    }
}
