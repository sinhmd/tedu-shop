using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        public String Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [MaxLength(50)]
        public String Type { get; set; }

        public virtual IEquatable<ProductTag> ProductTags { get; set; }
        public virtual IEquatable<PostTag> PostTags { get; set; }
    }
}