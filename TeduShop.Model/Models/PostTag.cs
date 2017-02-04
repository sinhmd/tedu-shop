using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("ProductTags")]
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }

        [Key]
        [MaxLength(50)]
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Product Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}