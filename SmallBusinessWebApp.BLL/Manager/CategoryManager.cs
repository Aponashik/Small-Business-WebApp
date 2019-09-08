using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Models.Models;
using SmallBusinessWebApp.Repository.Repository;

namespace SmallBusinessWebApp.BLL.Manager
{
    public class CategoryManager
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return categoryRepository.Add(category);
        }
        public bool Delete(Category category)
        {
            return categoryRepository.Delete(category);
        }
        public Category GetById(int Id)
        {
            return categoryRepository.GetById(Id);

        }
        public bool Update(Category category)
        {
            return categoryRepository.Update(category);
        }
        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

    }
}
