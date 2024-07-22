using Data.Entities;
using Service.Model;

namespace PRN221.Service.Model
{
    public class Session
    {
        public static Guid userid { get; set; }
        public static string email { get; set; }
        public static string roleName { get; set; }
        public static List<ProductModel> carts { get; set; }
    }
}
