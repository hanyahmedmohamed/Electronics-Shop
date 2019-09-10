using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Repository
{
    public interface IProductRepository
    {
        List<Product> LatestProducts(int  n);

        List<Product> LatestProducts();

        List<Product> FeaturedProducts(int  n);
        List<Product> SpecialProducts();
        List<Product> RelatedProducts(Product product ,int n);
        Product find(int id);
    }
}
