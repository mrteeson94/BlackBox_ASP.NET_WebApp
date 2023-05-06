namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeNameProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "TitleMembershipType", c => c.String(nullable: false));
            DropColumn("dbo.MembershipTypes", "MemberShipType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "MemberShipType", c => c.String(nullable: false));
            DropColumn("dbo.MembershipTypes", "TitleMembershipType");
        }
    }
}
