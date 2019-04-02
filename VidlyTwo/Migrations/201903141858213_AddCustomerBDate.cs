namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BDate");
        }
    }
}
