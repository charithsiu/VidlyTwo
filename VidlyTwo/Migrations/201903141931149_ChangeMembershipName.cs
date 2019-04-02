namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            DropColumn("dbo.MembershipTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
