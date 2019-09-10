using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2.Repository
{
    public class OrderDataRepository : IOrderDataRepository
    {
        private myDemEntities myDemEntities = new myDemEntities();



        public void create(OrderDetail orderDetail)
        {
            this.myDemEntities.OrderDetails.Add(orderDetail);
            this.myDemEntities.SaveChanges();
        }
    }
}