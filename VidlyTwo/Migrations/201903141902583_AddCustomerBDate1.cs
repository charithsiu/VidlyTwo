namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBDate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BDate", c => c.DateTime(nullable: false));
        }
    }
}
