using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [MaxLength(50)]
        public String Department { get; set; }
        [Required]
        [MaxLength(50)]
        public String Skype { get; set; }
        [MaxLength(50)]
        public String Mobile { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(50)]
        public String Facebook { get; set; }
        [MaxLength(50)]
        public bool Status { get; set; }
    }
}
