using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
