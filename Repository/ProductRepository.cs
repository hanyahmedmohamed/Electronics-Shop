using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private myDemEntities myDemEntities = new myDemEntities();


        public Product find(int id)
        {
            return myDemEntities.Products.Find(id);
        }



        public List<Product> LatestProducts(int n)
        {
            return myDemEntities.Products.OrderByDescending(p=>p.id).Take(n).ToList();
        }

        public List<Product> FeaturedProducts(int n)
        {
            return myDemEntities.Products.Where(p => p.specials == true).OrderByDescending(p => p.id).Take(n).ToList();
        }




        public List<Product> RelatedProducts(Product product, int n)
        {
            return myDemEntities.Products.Where(p => p.categoryId == product.categoryId && p.id != product.id).Take(n).ToList();
        }


        public List<Product> SpecialProducts()
        {
            return myDemEntities.Products.Where(p => p.specials == true).ToList();
        }


        public List<Product> LatestProducts()
        {
            return myDemEntities.Products.OrderByDescending(p=>p.id).ToList();

        }
    }
}