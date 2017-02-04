using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    interface ICommonProperty
    {
        DateTime CreatedDate { get; set;}
        String CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        String ModifiedBy { get; set; }
        String MetaKeyword { get; set; }
        bool Status { get; set; }
    }
}
