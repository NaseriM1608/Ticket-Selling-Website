using ModelsLayer.Context;
using ModelsLayer.Models;
using RepositoryLayer.Classes;
using RepositoryLayer.Interfaces;
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
        private readonly OrderRepository _OrderRepository;
        public OrderService(ApplicationDbContext context, OrderRepository orderRepository) : base(context)
        {
            _OrderRepository = orderRepository;
        }
        public Order GetOrderByUserId(int userId)
        {
            return _OrderRepository.GetAll().FirstOrDefault(o => o.UserId == userId);
        }
    }
}
