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
    [Table("Products")]
    public class Product : CommonProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        public String Alias { get; set; }
        public String Description { get; set; }
        public int CategoryId { get; set; }
        public String Image { get; set; }
        [Column(TypeName ="xml")]
        public string MoreImages { get; set; }
        public Decimal Price { get; set; }
        public Decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        public String Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? ViewFlag { get; set; }
        public int ViewCount { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public virtual IEquatable<ProductTag> ProductTags { get; set; }
    }
}
