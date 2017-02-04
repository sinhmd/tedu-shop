using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : CommonProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        [Required]
        public String Name;
        [Required]
        [Column(TypeName = "varchar")]
        public String Alias;
        public String Description;
        public int? ParentId;
        public int? DisplayOrder;
        public String Image;

        public bool? HomeFlag;

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
