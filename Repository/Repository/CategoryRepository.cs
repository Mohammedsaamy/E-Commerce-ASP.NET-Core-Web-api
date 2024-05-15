using Context;
using Microsoft.EntityFrameworkCore;
using Models.Model;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        EcommerceDB Context;
        DbSet<Category> dbset;

        public CategoryRepository(EcommerceDB _Context) : base(_Context)
        {
            Context = _Context;
            dbset = Context.Set<Category>();
        }
    }
}
