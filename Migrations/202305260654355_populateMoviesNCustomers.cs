namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMoviesNCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.Customers OFF ");
            Sql("SET IDENTITY_INSERT dbo.Movies OFF ");

            //Fill customers
            Sql("INSERT INTO dbo.Customers VALUES('Jessica Jones',1,4,'2000-12-7 09:00:00')");
            Sql("INSERT INTO dbo.Customers VALUES('Tyson Ng',1,1,'1993-11-20 09:00:00')");
            Sql("INSERT INTO dbo.Customers VALUES('Eric Song',0,3,'1990-03-2 09:00:00')");
            Sql("INSERT INTO dbo.Customers VALUES('Amanda Hassan',0,2,'2005-09-14 09:00:00')");
            Sql("INSERT INTO dbo.Customers VALUES('Duckold Trump',1,1,'1974-05-25 09:00:00')");

            //Fill Movies
            Sql("INSERT INTO dbo.Movies VALUES('Titanic','1997-12-17 09:00:00',8,5,'2023-05-23 09:00:00')");
            Sql("INSERT INTO dbo.Movies VALUES('Shrek','2001-05-21 09:00:00',10,1,'2023-05-23 09:00:00')");
            Sql("INSERT INTO dbo.Movies VALUES('Terminator','1984-12-20 09:00:00',5,3,'2023-05-23 09:00:00')");
            Sql("INSERT INTO dbo.Movies VALUES('Creed','2015-11-26 09:00:00',6,2,'2023-05-23 09:00:00')");
            Sql("INSERT INTO dbo.Movies VALUES('Happy Gilmore','1996-08-08 09:00:00',10,6,'2023-05-23 09:00:00')");
        }

        public override void Down()
        {
        }
    }
}
