namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipTypeValues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "TitleMembershipType", c => c.String(nullable: false, maxLength: 255));
            Sql("UPDATE dbo.MembershipTypes SET TitleMembershipType = 'Pay as you go' WHERE MembershipTypeId=1;");
            Sql("UPDATE dbo.MembershipTypes SET TitleMembershipType = 'Monthly' WHERE MembershipTypeId=2;");
            Sql("UPDATE dbo.MembershipTypes SET TitleMembershipType = 'Quarterly' WHERE MembershipTypeId=3;");
            Sql("UPDATE dbo.MembershipTypes SET TitleMembershipType = 'Annual' WHERE MembershipTypeId=4;");

        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "TitleMembershipType");
        }
    }
}
