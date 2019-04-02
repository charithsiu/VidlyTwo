namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            AddColumn("dbo.MembershipTypes", "SingUpFee", c => c.Int(nullable: false));
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Int(nullable: false));
            DropColumn("dbo.MembershipTypes", "GenreType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "GenreType", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "DiscountRate");
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
            DropColumn("dbo.MembershipTypes", "SingUpFee");
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
