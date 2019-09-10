using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Repository
{
    public interface ICategoryRepository
    {
        List<Category>  findAll();
        Category find(int id);
    }
}
