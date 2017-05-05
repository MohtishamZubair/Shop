
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
    class ProductControllerTest : BaseControllerTest
    {


        ProductController controller;
        Mock<IEntityService<Product>> service;
        Mock<IEntityService<Category>> serviceCategory;
        Product product;
        ProductView pv;

        [SetUp]
        public void setupForEachTest()
        {
            //Arrange
            service = new Mock<IEntityService<Product>>();
            serviceCategory = new Mock<IEntityService<Category>>();
            product = new Product { ProductId = 1, Name = "Nokia LTE 10i", ModelName = "NokialteN1", ModelNumber = "N134c1", MRP = 15000, Description = "the best ever only available" };

            var products = Enumerable.Range(0, 10).Select(
                pid => new Product
                {
                    ProductId = pid,
                    Name = string.Format("Name{0}", pid),
                    ModelName = string.Format("ModelName{0}", pid),
                    ModelNumber = string.Format("ModelNumber{0}", pid),
                    MRP = (decimal)Math.Pow(10, pid),
                    Description = string.Format("Description{0}", pid),
                });

            service.Setup(s => s.GetAll(1, 10)).Returns(products);
            controller = new ProductController(service.Object, serviceCategory.Object);
        }


        [Test]
        public void Product_Get_View()
        {
            //Act
            ActionResult result = controller.Index();
            
            //Assert
            Assert.IsNotNull(result, "View not found");
            service.Verify(s => s.GetAll(1, 10));
            Assert.IsInstanceOf<ViewResult>(result,"Base View Result there ");            
            Assert.IsNotNull(((ViewResult)result).Model,"Model is null ");
            Assert.IsTrue(((ViewResult)result).ViewData.Model is ProductViewAll, "ModelAll is not valid");
            
           var pvaModel = ((ViewResult)result).Model;
            ProductViewAll pva = (ProductViewAll)pvaModel;
            Assert.IsNotNull(pva.ProductViews, "Does not contains product views to display");
            Assert.IsTrue(pva.ProductViews is IEnumerable<ProductView>, "Does not contains product views to display");
            Assert.IsNotNull(pva.TotalCount, "Does not contains Total Count to handle paging");
            Assert.IsTrue(pva.TotalCount is int, "Does not contains product views to display");
            //Assert.IsNotNull(controller.ViewBag.Title, "Does not title to set ");



        }

        [Test]
        public void Create_GET_View()
        {
            //ACT
            ActionResult result = controller.Create();
            //Assert
            Assert.IsTrue(result is ViewResult);
            ViewResult vr = result as ViewResult;
            Assert.IsInstanceOf<ProductView>(vr.Model,"Modle is not valid");
            Assert.IsTrue(((vr.Model) as ProductView).CategoryList is IEnumerable<SelectListItem>, "Categories must be SelectlistItem");
        }


        [Test]
        public void Product_ProductView_Mapping()
        {
            //Act              
            pv = AutoMapperHelper.Get<Product, ProductView>(product);

            //Assert
            Assert.IsNotNull(pv);
            Assert.AreEqual(pv.Id, product.ProductId, "Id property is not matching");
            Assert.AreSame(pv.Name, product.Name, "Name property is not matching");
            Assert.AreEqual(pv.ModelName, product.ModelName, "ModelName property is not matching");
            Assert.AreEqual(pv.ModelNumber, product.ModelNumber, "ModelNumber property is not matching");
            Assert.AreEqual(pv.MRP, product.MRP, "MRP property is not matching");
            Assert.AreEqual(pv.Description, product.Description, "Description property is not matching");
        }

        [Test]
        public void ProductView_Product_Mapping()
        {
            //Arrange
            pv = new ProductView { Id = 3, Name = "Samsung LTE 10i", ModelName = "Samsung1bX2", ModelNumber = "SX3411", MRP = 11000, Description = "the Samsung again coming to top notch" };
            //Act            
            product = AutoMapperHelper.Get<ProductView, Product>(pv);

            //Assert
            Assert.IsNotNull(pv);
            Assert.AreEqual(pv.Id, product.ProductId, "Id property is not matching");
            Assert.AreSame(pv.Name, product.Name, "Name property is not matching");
            Assert.AreEqual(pv.ModelName, product.ModelName, "ModelName property is not matching");
            Assert.AreEqual(pv.ModelNumber, product.ModelNumber, "ModelNumber property is not matching");
            Assert.AreEqual(pv.MRP, product.MRP, "MRP property is not matching");
            Assert.AreEqual(pv.Description, product.Description, "Description property is not matching");

        }

        [TearDown]
        public void DisposeAfteralltests()
        {
            controller = null;
            service = null;
        }
    }

}
