﻿using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IOrderService : IEntityService<Order>
    {
        public Order GetOrderByUserId(int userId);
    }
}
