﻿namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMembershipRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId");
        }
    }
}
