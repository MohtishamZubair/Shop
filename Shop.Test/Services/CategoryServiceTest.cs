

namespace Shop.Test.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Shop.Services;
    using Shop.Repository;
    using Models;
    using Moq;
    using System.Linq.Expressions;

    [TestFixture]
    class CategoryServiceTest
    {
        ICategoryService service;
        static List<Category> categories;
        //<Shop.Data.Repository.ICategoryRepository> mockCategoryRepository;
        Mock<IEntityRepository<Category>> mockRepository;

        [SetUp]
        public void setupForEachTest()
        {
            //Arrange

             categories = Enumerable.Range(0, 5)
                                    .Select(x => new Category()
                                    {
                                        Name = string.Format("categoryname{0}", x),
                                        CategoryId = x,

                                    }).ToList();
            mockRepository = new Mock<IEntityRepository<Category>>();
            //mockCategoryRepository = new Mock<ICategoryRepository>();
            
            mockRepository.Setup(r => r.GetAll(It.IsAny<int>(), It.IsAny<int>())).Returns(categories);
            // it has callback to mimic the internal behavior it is more like stub then mock
            //mockCategoryRepository.Setup(r => r.Add(It.IsAny<Category>())).Callback((Category c)=> { categories.Add(c);categories.Sort((c1, c2) => (c1.CategoryId.CompareTo(c2.CategoryId))); }).Returns((Category c)=>c.CategoryId);
            //mockCategoryRepository.Setup(r => r.Save(It.IsAny<Category>())).Returns((Category c) => c.CategoryId);
            //mockCategoryRepository.Setup(r => r.Add(It.IsAny<Category>())).Returns((Category c) => c.CategoryId);
            //mockCategoryRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Category, bool>>>())).Returns((Expression<Func<Category,bool>> expr) => categories.Where<Category>(expr.Compile()).SingleOrDefault());
            service = new CategoryService(mockRepository.Object);
        }

        [Test]
        public void BaseServiceContext()
        {

            var result = false;
            //Act
            result = service is BaseService;
            //Assert
            Assert.IsTrue(result);

        }


        [Test]
        public void CategoryServiceGetAll()
        {
            //Act
            List<Category> result = service.GetAll(2,3);
            //Assert
            Assert.IsNotNull(result);
            mockRepository.Verify(rep=>rep.GetAll(It.IsAny<int>(), It.IsAny<int>()));

        }

        //[Test]
        //public void CategoryService_GetCategoryById()
        //{
        //    //Act
        //    Category result = service.GetCategoryById(3);
        //    //Assert
        //    Assert.IsNotNull(result);
        //    mockRepository.Verify(rep => rep.Get(It.IsAny<Expression<Func<Category, bool>>>()));

        //}

        //[Test]
        //public void CategoryServiceAdd()
        //{
        //    //Arrange
        //    int newCategoryId = 7;
        //    Category newCategory = new Category { CategoryId = newCategoryId, Name = "Electronics" };
        //    //Act
        //    int newlyCatgoryId = service.Add(newCategory);
        //    //Assert
        //    Assert.AreEqual(newCategoryId,newlyCatgoryId);            
        //    mockCategoryRepository.Verify(rep=>rep.Add(It.IsAny<Category>()),"Add method of rep was not called");            
        //}

        //[Test]
        //public void CategoryService_Save()
        //{
        //    //Arrange
        //    int saveId = 7;
        //    Category Category = new Category { CategoryId = saveId, Name = "Electronics" };
        //    //Act
        //    int savedCatgoryId = service.Save(Category);
        //    //Assert
        //    Assert.AreEqual(saveId, savedCatgoryId);
        //    mockCategoryRepository.Verify(rep => rep.Save(It.IsAny<Category>()), "save method of rep was not called");
        //}




        [TearDown]
        public void DisposeAfteralltests()
        {
            //to do
            //service.Dispose();
            service = null;
            categories = null;
            mockRepository = null;
        }
    }

}
