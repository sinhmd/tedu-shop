using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String CustomerName { get; set; }
        [MaxLength(50)]
        [Required]
        public String CustomerEmail { get; set; }
        [MaxLength(250)]
        [Required]
        public String CustomerAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public String CustomerMobile { get; set; }

        public String CustomerMessage { get; set; }
        [Required]
        public String PaymentMethod { get; set; }
        [Required]
        public String PaymentStatus { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
