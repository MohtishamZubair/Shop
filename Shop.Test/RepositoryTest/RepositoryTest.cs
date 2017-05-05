namespace Shop.Test.RepositoryTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Shop.Services;
    using Repository;
    using Models;
    using Moq;
    using Data.Context;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using System.Data.Entity.Infrastructure;

    [TestFixture]
    class CategoryRepositoryTest
    {
        //ICategoryRepository repository;
        //Mock<ApplicationDbContext> dbCtx;
        //IEnumerable<Category> categoriesEnumberable;

        //[SetUp]
        //public void setupForEachTest()
        //{
            
        //    categoriesEnumberable = Enumerable.Range(1, 5)
        //            .Select(x => new Category()
        //            {
        //                Name = string.Format("categoryname{0}", x),
        //                CategoryId = x,

        //            });
        //    Category cat = new Category { CategoryId = 3, Name = "Electronics", SubCategoryId = null };
        //    Mock<DbEntityEntry<Category>> entryMock = new Mock<DbEntityEntry<Category>>();
        //    Mock<DbSet<Category>> dbSetMockCategory = GetMockDbSet<Category>(categoriesEnumberable.AsQueryable());
        //    var modifiedcat = categoriesEnumberable.FirstOrDefault();
        //    modifiedcat.Name = "Name changed";
        //    entryMock.SetReturnsDefault(modifiedcat);
        //    //dbSetMockCategory.Setup(x => x.SingleOrDefault<Category>()).Returns(It.IsAny<Category>());
        //    dbCtx = new Mock<ApplicationDbContext>();
        //    //dbCtx.Setup(x => x.Entry(categoriesEnumberable.FirstOrDefault())).Returns(entryMock.Object);

        //    dbCtx.SetupGet(context => context.Categories).Returns(dbSetMockCategory.Object);
        //    dbCtx.Setup(context => context.SaveChanges()).Returns(It.IsAny<Int16>());
            
        //    repository = new CategoryRepository(dbCtx.Object);
        //}

        //private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> dataForDbSet) where T:class
        //{
        //    var dbsetMock = new Mock<DbSet<T>>();
        //    dbsetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(dataForDbSet.Provider);
        //    dbsetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(dataForDbSet.Expression);
        //    dbsetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(dataForDbSet.ElementType);
        //    dbsetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(dataForDbSet.GetEnumerator());

        //    //  dbsetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(dbSetData.AsQueryable().GetEnumerator());            
        //    return dbsetMock;         
        //}

        //[Test]
        //public void CategoryGetAll()
        //{
        //    //Act
        //    List<Category> result = repository.GetAll(1);
        //    //Assert
        //    Assert.AreEqual(result.Count, categoriesEnumberable.Count());
        //    dbCtx.VerifyGet(x => x.Categories);

        //}

        //[Test]
        //public void CategoryRepository_Save()
        //{

        //    Category cat = new Category { CategoryId = 3, Name = "Electronics",SubCategoryId=null};
        //    //Act
        //    int result = repository.Save(cat);
        //    //Assert
            
        //    dbCtx.Verify(x => x.SaveChanges());
        //   // dbCtx.VerifyGet(x => x.SaveChanges());

        //}


        //[Test]
        //public void CategoryRepository_Get()
        //{

        //    Func<Category, bool> func = (c) => c.CategoryId == 3;
        //    Expression<Func<Category, bool>> filter = cat => func(cat);


        //    //Act
        //    Category result = repository.Get(filter);
        //    //Assert
        //    Assert.AreEqual(result.CategoryId, 3, "ids are not matched");
        //    dbCtx.VerifyGet(x => x.Categories);

        //}
        //[TearDown]
        //public void DisposeAfteralltests()
        //{
        //    dbCtx = null;
        //    repository = null;
        //}
    }

}
