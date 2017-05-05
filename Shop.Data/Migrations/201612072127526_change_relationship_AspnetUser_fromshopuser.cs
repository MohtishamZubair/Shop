namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_relationship_AspnetUser_fromshopuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deliverables", "ShopUserId", "dbo.ShopUsers");
            DropIndex("dbo.Deliverables", new[] { "ShopUserId" });
            AddColumn("dbo.Deliverables", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Deliverables", "ApplicationUserId");
            AddForeignKey("dbo.Deliverables", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Deliverables", "ShopUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deliverables", "ShopUserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Deliverables", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Deliverables", new[] { "ApplicationUserId" });
            DropColumn("dbo.Deliverables", "ApplicationUserId");
            CreateIndex("dbo.Deliverables", "ShopUserId");
            AddForeignKey("dbo.Deliverables", "ShopUserId", "dbo.ShopUsers", "ShopUserId");
        }
    }
}
