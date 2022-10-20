using Data.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> categoryRepo = new GenericRepository<Category>();
        public List<Category> GetAllBl()
        {
            return categoryRepo.List();
        }
        public void CategoryAddBl(Category category)
        {
            categoryRepo.Insert(category);
        }
    }
}
