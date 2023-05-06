namespace blackBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.Genres ON");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(1,'Family')");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(2,'Adventure')");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(3,'Action')");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(4,'Horror')");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(5,'Romance')");
            Sql("INSERT INTO Genres(GenreId, GenreTitle) VALUES(6,'Comedy')");
            Sql("SET IDENTITY_INSERT dbo.Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
