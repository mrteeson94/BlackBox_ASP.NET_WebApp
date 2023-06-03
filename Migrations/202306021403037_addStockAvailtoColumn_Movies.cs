namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStockAvailtoColumn_Movies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAvailability", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET StockAvailability = NoOfStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAvailability");
        }
    }
}
