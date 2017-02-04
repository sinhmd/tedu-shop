using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeduShop.Model.Models
{
    [Table("Posts")]
    public class Post : CommonProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public String Alias { get; set; }
        public String Description { get; set; }
        public int CategoryId { get; set; }
        public String Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? ViewFlag { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { get; set; }

        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
}
