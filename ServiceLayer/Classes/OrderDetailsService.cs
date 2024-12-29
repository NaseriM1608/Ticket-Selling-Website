using ModelsLayer.Context;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class OrderDetailsService : EntityService<OrderDetails>, IOrderDetailsService
    {
        public OrderDetailsService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
