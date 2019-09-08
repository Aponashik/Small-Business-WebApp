using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Databse.DatabseContext;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Repository.Repository
{
    public class CategoryRepository
    {
        SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Category category)
        {
            int isExecuted = 0;
            db.Categories.Add(category);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }
        public bool Delete(Category category)
        {
            int isExecuted = 0;
            Category acategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (acategory != null)
            {
                db.Categories.Remove(acategory);
                isExecuted= db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            return false;
        }
        public Category GetById(int Id)
        {
            Category acategory = db.Categories.FirstOrDefault(c => c.Id == Id);
            return acategory;
        }

        public bool Update(Category category)
        {
            int isExecuted = 0;
            //Method 1
            //Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            //if (aStudent != null)
            //{
            //    aStudent.Name = student.Name;
            //    isExecuted = db.SaveChanges();
            //}

            //Method 2
            db.Entry(category).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
    }
}
