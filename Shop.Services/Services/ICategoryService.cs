using Shop.Models;
using System.Collections.Generic;
using System;
using Shop.Repository;
using System.Linq;

namespace Shop.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll(int pageNumber = 1, int pagesize = 10);
        int Add(Category newCategory);
        Category Save(Category category);
        Category GetCategoryById(int id);
    }

    public class CategoryService : BaseService, ICategoryService
    {
        private IEntityRepository<Category> repository;

        public CategoryService(IEntityRepository<Category> repository)
        {
            this.repository = repository;
        }

        int ICategoryService.Add(Category newCategory)
        {
            var cat = repository.Add(newCategory);
            return cat.CategoryId;
        }

        List<Category> ICategoryService.GetAll(int pageNumber=1, int pagesize = 10)
        {
           return repository.GetAll(pageNumber,pagesize).ToList();
        }

        Category ICategoryService.GetCategoryById(int id)
        {
            return repository.Get(c => c.CategoryId == id);
        }

        Category ICategoryService.Save(Category category)
        {
            return repository.Save(category);
        }

    }
}