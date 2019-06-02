using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models
{
   
     public class OrdersContext : DbContext
    {
        public virtual DbSet<Orders> OrderItems { get; set; }
        public virtual DbSet<BuyerViewModel> BuyerId { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
