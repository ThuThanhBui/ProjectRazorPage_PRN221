using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string? Image { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Telephone { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Blog>? Blogs { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<ProductFeedback>? ProductFeedbacks { get; }
    }

}
