using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Repository;
using Task2.Models;

namespace task.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        private IOrderRepository iOrderRepository = new OrderRepository();
        private IOrderDataRepository iOrderDataRepository = new OrderDataRepository(); 

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Buy(int id)
        {
            //law mafe4 7aga 3andy fe el cart
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item()
                {
                    product = iProductRepository.find(id),
                    quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if(index == -1)
                { 
                cart.Add(new Item()
                {
                    product = iProductRepository.find(id),
                    quantity = 1
                });
                } else
                {
                    cart[index].quantity = cart[index].quantity + 1;
                }
                Session["cart"] = cart;
            }
            return View("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.id == id)
                    return i;
            return -1;
        }

        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("Index");
        }

        public ActionResult Checkout()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("MyAccount", "Account");
            }
            else
            {
            List<Item> cart = (List<Item>)Session["cart"];
            //save order
            Order order = new Order();
            order.creationDate = DateTime.Now;
            order.name = "New Order";
                
            order.payement = "Paypal";
            order.status = "true";
            order.userName = Session["username"].ToString();
            int orderId = iOrderRepository.create(order);
            //save order details
            foreach (var item in cart)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.orderId = orderId;
                orderDetail.productId = item.product.id;
                orderDetail.price = (int)item.product.price;
                orderDetail.quantity = item.quantity;
                iOrderDataRepository.create(orderDetail);

            }
            //remove cart
            Session.Remove("cart");
            return View("Thanks");
        }
        }
	}
}