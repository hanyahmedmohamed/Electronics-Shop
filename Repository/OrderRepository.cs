using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private myDemEntities myDemEntities = new myDemEntities();


        public int create(Order order)
        {
            this.myDemEntities.Orders.Add(order);
            this.myDemEntities.SaveChanges();
            return order.id;
        }
    }
}