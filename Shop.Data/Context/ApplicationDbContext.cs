using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Models;
using Shop.Repository;
using System.Data.Entity;
using System;

namespace Shop.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IContextRepository
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false){}

        public ApplicationDbContext(string connectionString) : base(connectionString){}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        IDbSet<T> IContextRepository.Set<T>()
        {
            return base.Set<T>();
        }

        public virtual IDbSet<ShopUser> ShopUsers { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<ProductListing> ProductListings { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<OrderItem> OrderItems { get; set; }
        public virtual IDbSet<Invoice> Invoices { get; set; }
        public virtual IDbSet<Deliverable> Deliverables { get; set; }
        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasOptional<Category>(c => c.SubCategory)
                .WithMany(c => c.SubCategories);                      

        }
        //public System.Data.Entity.DbSet<Shop.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}