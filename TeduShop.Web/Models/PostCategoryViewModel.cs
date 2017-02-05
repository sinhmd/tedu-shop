using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public String Description { get; set; }
        public int? ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        public String Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String ModifiedBy { get; set; }
        public String MetaKeyword { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<PostViewModel> Posts { get; set; }
    }
}