using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid id {  get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public DateTime DOB { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public Guid roleId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductFeedback> ProductFeedbacks { get;}
    }
}
