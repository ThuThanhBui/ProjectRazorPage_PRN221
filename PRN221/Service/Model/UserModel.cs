using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class UserModel
    {
        //public string email { get; set; }
        //public string password { get; set; }
        //public string fullName { get; set; }
        //public string telephone { get; set; }
        //public string gender { get; set; }
        //public string address { get; set; }


        //XuanViet
        public Guid Id { get; set; }
        public string Img { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public Guid RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
