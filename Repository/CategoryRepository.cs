using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private myDemEntities myDemEntities = new myDemEntities();

        public List<Category> findAll()
        {
            return myDemEntities.Categories.ToList();
        }


        public Category find(int id)
        {
            return myDemEntities.Categories.Find(id);
        }
    }
}