using ModelsLayer.Context;
using ModelsLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        public OrderService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
