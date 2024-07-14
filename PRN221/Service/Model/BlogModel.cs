using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class BlogModel
    {
        public Guid id { get; set; }
        public string? img { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public Guid userId { get; set; }
        public  UserModel? User { get; set; }
    }
}
