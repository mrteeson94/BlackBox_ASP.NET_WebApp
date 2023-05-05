namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityMembership : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.MembershipTypes OFF ");
        }
        
        public override void Down()
        {
        }
    }
}
