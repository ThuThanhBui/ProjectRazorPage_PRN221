using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class UserModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string telephone { get; set; }
        public DateTime DOB { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
    }
}
