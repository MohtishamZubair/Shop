using NUnit.Framework;
using Shop.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Controllers;
using Shop.Models;
using Moq;
using Shop.Services;
using System.Web.Mvc;

namespace ControllerTest
{    
    [TestFixture]
     class ListingControllerTest : BaseControllerTest
    {
        ListingController instance = null;
        Mock<IEntityService<ProductListing>> service;

        [SetUp]
        public void setupForEachTest()
        {
            service = new Mock<IEntityService<ProductListing>>();
            service.Setup(s => s.GetAll(1, 10)).Returns(It.IsAny<IEnumerable<ProductListing>>());
            //Arrange            
            instance = new ListingController(service.Object);
        }

        [Test]
        public void Instance_Test_Index()
        {
            //Act                       
            var result = instance.Index();
            
            //Assert
             Assert.IsNotNull(result,"View not found");
            Assert.IsInstanceOf<ActionResult>(result,"View is not ActionResult");
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult, "View is not ViewResult");
            Assert.IsNotNull(viewResult.Model, "Model is not loaded");
            Assert.IsInstanceOf<IEnumerable<ProductListing>>(viewResult.Model,"Model nolt of productlisting");
            service.VerifyAll();
        }


        [TearDown]
        public void TearDownORDisposeAfteralltests()
        {
            service = null;
                instance = null;
        }

    }
}
