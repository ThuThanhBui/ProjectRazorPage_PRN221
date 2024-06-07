using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public Guid id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid userId { get; set; }
        public virtual User User { get; set; }
    }
}
