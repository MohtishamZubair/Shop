using Shop.Models;
using System.Collections.Generic;
using System;
using Shop.Data.Context;
using System.Linq.Expressions;
using System.Linq;

namespace Shop.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(int pageNumber=1, int pagesize = 10);
        int Add(Category newCategory);
        Category Get(Expression<Func<Category, bool>> expression);
        int Save(Category category);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public List<Category> GetAll(int pageNumber=1, int pagesize = 10)
        //{

        //    return new List<Category>(context.Categories);
        //        //return new List<Category>();
        //}

        int ICategoryRepository.Add(Category newCategory)
        {
           var newlyCategory = context.Categories.Add(newCategory);
            int ctxResult = context.SaveChanges();
            return newlyCategory.CategoryId;
        }

        Category ICategoryRepository.Get(Expression<Func<Category, bool>> expression)
        {
            
            Category category = context.Categories.FirstOrDefault(expression);
            return category;
        }

        List<Category> ICategoryRepository.GetAll(int pageNumber=1, int pagesize=10)
        {

            return new List<Category>(context.Categories);
        }

        int ICategoryRepository.Save(Category category)
        {
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            int noOfChanges = context.SaveChanges();
            return noOfChanges;
        }
    }
}