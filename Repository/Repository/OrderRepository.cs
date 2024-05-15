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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        EcommerceDB Context;
        DbSet<Order> dbset;

        public OrderRepository(EcommerceDB _Context) : base(_Context)
        {
            Context = _Context;
            dbset = Context.Set<Order>();
        }
    }
    
}
