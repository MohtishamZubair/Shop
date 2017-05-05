using Shop.Models;

namespace Shop.Test.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System.Web;
    using Shop.Services;
    using Repository;
    using System.Web.Mvc;
    using Models;
    using Moq;
    using Controllers;

    [TestFixture]
    class CategoryControllerTest
    {


        Mock<ICategoryService> mockCategoryService;
        CategoryController controller;
        Category category;
        CategoryView cv;

        [SetUp]
        public void setupForEachTest()
        {
            //Arrange
            mockCategoryService = new Mock<ICategoryService>();
            AutoMapperHelper.LoadMapping();
            category = new Category { CategoryId = 3, Name = "machine" };
            ResultModel resultModel = new ResultModel { ResultState = true, ResultId = "3", ResultMessage = "Successfully Save" };
            mockCategoryService.Setup(r => r.Save(It.IsAny<Category>())).Returns((Category c) => c);
            mockCategoryService.Setup(r => r.GetCategoryById(It.IsAny<int>())).Returns(category);
            controller = new CategoryController(mockCategoryService.Object);
        }

        [Test]
        public void Category_CategoryView_Mapping()
        {
            //Act            
            cv = AutoMapperHelper.Get<Category, CategoryView>(category);

            //Assert
            Assert.IsNotNull(cv);
            Assert.AreSame(cv.Name, category.Name, "Name property is not matching");
            Assert.AreEqual(cv.Id, category.CategoryId, "Id property is not matching");
        }

        [Test]
        public void CategoryView_Category_Mapping()
        {
            //Arrange
            cv = new CategoryView { Id = 3, Name = "Dress" };
            //Act            
            Category CategoryMapped = AutoMapperHelper.Get<CategoryView, Category>(cv);

            //Assert
            Assert.IsNotNull(cv);
            Assert.AreSame(cv.Name, CategoryMapped.Name, "Name property is not matching");
            Assert.AreEqual(cv.Id, CategoryMapped.CategoryId, "Id property is not matching");
        }

        [Test]
        public void Category_Edit_Get_View()
        {
            //Act                       
            ActionResult result = controller.Edit(3);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult vr = result as ViewResult;
            Assert.IsInstanceOf<CategoryView>(vr.Model);
            Assert.IsInstanceOf<IEnumerable<CategoryView>>(vr.ViewBag.SubCategoryId, "Viewbag not set");

            mockCategoryService.Verify(s => s.GetCategoryById(It.IsAny<int>()));
        }

        [Test]
        public void Category_Edit_Post_View()
        {
            cv = AutoMapperHelper.Get<Category, CategoryView>(category);
            //Act                       
            ActionResult result = controller.Edit(cv);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult vr = result as ViewResult;
            Assert.IsInstanceOf<CategoryViewAll>(vr.Model, "not redirected to index page");
            Assert.AreEqual(((CategoryViewAll)vr.Model).HighLightId.Value, cv.Id, "edited objected is not valid");

            //mockCategoryService.VerifyAll();
        }


        [TearDown]
        public void DisposeAfteralltests()
        {
            controller = null;
            mockCategoryService = null;
        }
    }

}
