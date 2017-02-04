using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IVisitorStatiticRepository
    {
    }
    public class VisitorStatiticRepository : RepositoryBase<VisitorStatitic>, IVisitorStatiticRepository
    {
        public VisitorStatiticRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
