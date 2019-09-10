using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Repository;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
       private IProductRepository iProductRepository = new ProductRepository();

        public ActionResult Index()
        {
            ViewBag.latestProducts = iProductRepository.LatestProducts(3);
            ViewBag.featuredProducts = iProductRepository.FeaturedProducts(2);
            return View();
        }
	}
}