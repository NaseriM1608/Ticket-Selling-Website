using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;

namespace ModelsLayer.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
