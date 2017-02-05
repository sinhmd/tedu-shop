using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class TagViewModel
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public String Type { get; set; }

        public virtual IEquatable<PostTagViewModel> PostTags { get; set; }
    }
}