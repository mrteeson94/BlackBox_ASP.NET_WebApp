namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.MembershipTypes ON");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES(2,30,1,10)");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES(3,90,3,15)");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES(4,300,12,20)");
            Sql("SET IDENTITY_INSERT dbo.MembershipTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
