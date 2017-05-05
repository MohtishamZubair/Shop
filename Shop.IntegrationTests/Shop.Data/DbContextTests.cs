using NUnit.Framework;
using Shop.Data.Context;
using Shop.Models;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IntegrationTests.Shop.Data
{
    [TestFixture]
    class DbContextIntTests
    {
        private ApplicationDbContext _dbcontext;
        private ICategoryRepository repository;
        [SetUp]
        public void setup()
        {
             repository =new CategoryRepository(_dbcontext);
        }
         
        [Test]
        public void AddCategory()
        {
            //act
            var category = new Category { Name = "electrical" };
            var categoryId = repository.Add(category);
            //assert
            var categorydb = _dbcontext.Categories.SingleOrDefault();
                //_dbcontext.Categories.Where(c => c.Name == "electronis").SingleOrDefault();
            Assert.AreEqual(category.Name, categorydb.Name);
        }

        public void destroy()
        {
            _dbcontext = null;
            repository = null;
        }

    }
}
