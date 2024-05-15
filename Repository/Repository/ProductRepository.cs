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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        EcommerceDB Context;
        DbSet<Product> dbset;

        public ProductRepository(EcommerceDB _Context) : base(_Context)
        {
            Context = _Context;
            dbset = Context.Set<Product>();
        }


    }
}
