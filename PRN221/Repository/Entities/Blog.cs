using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Blog")]
    public class Blog : BaseEntity
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
    }

}
