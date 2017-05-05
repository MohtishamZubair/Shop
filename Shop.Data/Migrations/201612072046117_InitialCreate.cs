namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        ShopUserId = c.String(maxLength: 128),
                        HouseNo = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        AreaCode = c.String(nullable: false),
                        LatLocation = c.Double(nullable: false),
                        LongLocation = c.Double(nullable: false),
                        ZipCode = c.String(nullable: false),
                        AddressType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.ShopUsers", t => t.ShopUserId)
                .Index(t => t.ShopUserId);
            
            CreateTable(
                "dbo.ShopUsers",
                c => new
                    {
                        ShopUserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        ContactNumber = c.String(),
                        CellNumber = c.String(),
                        OfficeNumber = c.String(),
                        Website = c.String(),
                        Notes = c.String(),
                        MiscelleneousInfo = c.String(),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShopUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ShopUserId)
                .Index(t => t.ShopUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SkypeId = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryId = c.Int(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.SubCategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ModelNumber = c.String(maxLength: 200),
                        ModelName = c.String(maxLength: 200),
                        Description = c.String(storeType: "ntext"),
                        MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        ProductAttributeId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductAttributeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductListings",
                c => new
                    {
                        ProductListingId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ShopUserId = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        QuantityType = c.Int(nullable: false),
                        PerQuantityType = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        DiscountQuantity = c.Int(nullable: false),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductListingId)
                .ForeignKey("dbo.ShopUsers", t => t.ShopUserId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShopUserId);
            
            CreateTable(
                "dbo.Deliverables",
                c => new
                    {
                        DeliverableId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(),
                        AddressId = c.Int(),
                        ShopUserId = c.String(maxLength: 128),
                        DeliveryTime = c.DateTime(),
                        Status = c.Int(),
                        Notes = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeliverableId)
                .ForeignKey("dbo.ShopUsers", t => t.ShopUserId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.InvoiceId)
                .Index(t => t.AddressId)
                .Index(t => t.ShopUserId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        RefernceId = c.Int(nullable: false),
                        ReferenceName = c.String(),
                        ActivtyAction = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Deliverable_DeliverableId = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Deliverables", t => t.Deliverable_DeliverableId)
                .Index(t => t.Deliverable_DeliverableId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceRefId = c.Int(),
                        OrderId = c.Int(nullable: false),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceRefId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.InvoiceRefId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderRefId = c.Int(),
                        ShopUserId = c.String(maxLength: 128),
                        OrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        IsPartial = c.Boolean(nullable: false),
                        OrderNotes = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Orders", t => t.OrderRefId)
                .ForeignKey("dbo.ShopUsers", t => t.ShopUserId)
                .Index(t => t.OrderRefId)
                .Index(t => t.ShopUserId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductListingId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductListings", t => t.ProductListingId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductListingId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Category_CategoryId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Deliverables", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Deliverables", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Orders", "ShopUserId", "dbo.ShopUsers");
            DropForeignKey("dbo.Orders", "OrderRefId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ProductListingId", "dbo.ProductListings");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "InvoiceRefId", "dbo.Invoices");
            DropForeignKey("dbo.Deliverables", "ShopUserId", "dbo.ShopUsers");
            DropForeignKey("dbo.Activities", "Deliverable_DeliverableId", "dbo.Deliverables");
            DropForeignKey("dbo.Categories", "SubCategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductListings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductListings", "ShopUserId", "dbo.ShopUsers");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ShopUsers", "ShopUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "ShopUserId", "dbo.ShopUsers");
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderItems", new[] { "ProductListingId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ShopUserId" });
            DropIndex("dbo.Orders", new[] { "OrderRefId" });
            DropIndex("dbo.Invoices", new[] { "OrderId" });
            DropIndex("dbo.Invoices", new[] { "InvoiceRefId" });
            DropIndex("dbo.Activities", new[] { "Deliverable_DeliverableId" });
            DropIndex("dbo.Deliverables", new[] { "ShopUserId" });
            DropIndex("dbo.Deliverables", new[] { "AddressId" });
            DropIndex("dbo.Deliverables", new[] { "InvoiceId" });
            DropIndex("dbo.ProductListings", new[] { "ShopUserId" });
            DropIndex("dbo.ProductListings", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "SubCategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ShopUsers", new[] { "ShopUserId" });
            DropIndex("dbo.Addresses", new[] { "ShopUserId" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Activities");
            DropTable("dbo.Deliverables");
            DropTable("dbo.ProductListings");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShopUsers");
            DropTable("dbo.Addresses");
        }
    }
}
