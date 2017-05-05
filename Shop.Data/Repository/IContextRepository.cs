using Shop.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shop.Repository
{
    public interface IContextRepository
    {
        IDbSet<ShopUser> ShopUsers { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<ProductListing> ProductListings { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderItem> OrderItems { get; set; }
        IDbSet<Invoice> Invoices { get; set; }
        IDbSet<Deliverable> Deliverables { get; set; }
        IDbSet<Address> Addresses { get; set; }
        IDbSet<Activity> Activities { get; set; }


        
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

    }
}