using Moq;
using NUnit.Framework;
using Shop.Models;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test.RepositoryTest
{
    [TestFixture]
    class GenericRepositoryTest
    {
        IEntityRepository<Category> repository;
        Mock<IContextRepository> contextRepository;


        [SetUp]
        public void setuptest()
        {

            var categoriesEnumberable = Enumerable.Range(1, 5)
                    .Select(x => new Category()
                    {
                        Name = string.Format("categoryname{0}", x),
                        CategoryId = x,
                    });

            Mock<DbSet<Category>> dbSetMockCategory = GetMockDbSet<Category>(categoriesEnumberable.AsQueryable());
            contextRepository = new Mock<IContextRepository>();
            contextRepository.Setup(c => c.Set<Category>()).Returns(dbSetMockCategory.Object);
            repository = new EntityRepository<Category>(contextRepository.Object);
        }


        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> dataForDbSet) where T : class
        {
            var dbsetMock = new Mock<DbSet<T>>();
            dbsetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(dataForDbSet.Provider);
            dbsetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(dataForDbSet.Expression);
            dbsetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(dataForDbSet.ElementType);
            dbsetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(dataForDbSet.GetEnumerator());

            //  dbsetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(dbSetData.AsQueryable().GetEnumerator());            
            return dbsetMock;
        }

        [Test]
        public void RepositoryType()
        {

            Assert.IsInstanceOf<IEntityRepository<Category>>(repository);
        }

        [Test]
        public void GetAll()
        {
            //act
            var cats = repository.GetAll(1, 10);

            //assert
            Assert.IsNotNull(cats, "null categores found!");
            Assert.IsInstanceOf<IEnumerable<Category>>(cats);
        }


        [TearDown]
        public void DisposeAfteralltests()
        {
            //to do
            //service.Dispose();
            repository = null;
            contextRepository = null;
        }
    }
}
