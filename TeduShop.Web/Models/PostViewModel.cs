using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public String Description { get; set; }
        public int CategoryId { get; set; }
        public String Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? ViewFlag { get; set; }

        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String ModifiedBy { get; set; }
        public String MetaKeyword { get; set; }
        public bool Status { get; set; }

        public virtual PostCategoryViewModel PostCategory { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
    }
}