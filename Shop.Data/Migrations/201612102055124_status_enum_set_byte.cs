namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status_enum_set_byte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deliverables", "Status", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Deliverables", "Status", c => c.Int());
        }
    }
}
